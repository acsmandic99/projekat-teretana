package infrastructure

import (
	"context"
	"fmt"
	"log"
	"os"
	"teretana-app/internal/domain"

	"github.com/jackc/pgx/v5"
	"github.com/joho/godotenv"
)

type PostgresRepository struct {
	Conn *pgx.Conn
}

func NewDatabase() (*PostgresRepository, error) {
	err := godotenv.Load()
	if err != nil {
		log.Fatalf("Neuspešno učitavanje .env fajla: %v", err)
		return nil, err
	}
	dbURL := os.Getenv("DATABASE_URL")
	if dbURL == "" {
		return nil, fmt.Errorf("DATABASE_URL nije postavljen")
	}

	conn, err := pgx.Connect(context.Background(), dbURL)
	if err != nil {
		log.Fatalf("Neuspesna koneckija sa bazom: %v", err)
		return nil, err
	}

	fmt.Println("Uspesno povezano na bazu")
	return &PostgresRepository{Conn: conn}, nil
}

func (db *PostgresRepository) Close() {
	if db.Conn != nil {
		db.Conn.Close(context.Background())
		fmt.Println("Konekcija zatvorena")
	}
}

func (repo *PostgresRepository) GetByIDClan(id int) (*domain.Clan, error) {
	query := `SELECT clan.id,ime,prezime,dat_uclanjenja FROM clan
			where clan.id = $1`

	row := repo.Conn.QueryRow(context.Background(), query, id)

	var clan domain.Clan
	err := row.Scan(&clan.Id, &clan.Ime, &clan.Prezime, &clan.Dat_uclanjenja)
	if err != nil {
		if err == pgx.ErrNoRows {
			return nil, fmt.Errorf("nema rezultata za id: %d", id)
		}
		log.Println("Greska pri izvrsavanju upita:", err)
		return nil, err
	}
	repo.GetClansClanstva(&clan)
	repo.GetClansTrenings(&clan)
	return &clan, nil
}

func (repo *PostgresRepository) GetClansClanstva(clan *domain.Clan) error {
	query := `SELECT datum_pocetka,datum_kraja,naziv
			FROM clan LEFT JOIN clanstvo on clan.id = clanstvo.clan_id 
			LEFT JOIN paket on paket.id = clanstvo.paket_id
			where clan.id = $1`
	rows, err := repo.Conn.Query(context.Background(), query, clan.Id)
	if err != nil {
		return fmt.Errorf("greska pri izvrsavanju upita: %v", err)
	}
	defer rows.Close()
	for rows.Next() {
		var clanstvo domain.Clanstvo
		err := rows.Scan(&clanstvo.Datum_pocetka, &clanstvo.Datum_kraja, &clanstvo.Paket_naziv)
		if err != nil {
			log.Println("Greska pri skeniranju clanstva", err)
			continue
		}
		clan.Clanstva = append(clan.Clanstva, clanstvo)
	}
	if err := rows.Err(); err != nil {
		return fmt.Errorf("greska pri citanju rezultata: %v", err)
	}

	return nil
}

func (repo *PostgresRepository) GetClansTrenings(clan *domain.Clan) error {
	query := `SELECT vreme_poc_treninga,vreme_kraj_treninga FROM clan
LEFT JOIN trenira on clan.id = trenira.clan_id
LEFT JOIN trening on trenira.trening_id = trening.id
where clan.id = $1`
	rows, err := repo.Conn.Query(context.Background(), query, clan.Id)
	if err != nil {
		return fmt.Errorf("greska pri izvrsavanju upita: %v", err)
	}
	defer rows.Close()
	for rows.Next() {
		var trening domain.Trening
		err := rows.Scan(&trening.Vreme_poc_treninga, &trening.Vreme_kraj_treninga)
		if err != nil {
			log.Println("Greska pri skeniranju treninga", err)
			continue
		}
		clan.Treninzi = append(clan.Treninzi, trening)
	}
	if err := rows.Err(); err != nil {
		return fmt.Errorf("greska pri citanju rezultata: %v", err)
	}
	return nil
}

// mora imati vazeci id u member i postavljene izmenjene vrednosti
func (repo *PostgresRepository) UpdateClan(member *domain.Clan) error {
	query := `UPDATE clan
				SET ime=$1,prezime = '$2', dat_uclanjenja = $3
				where id = $4`
	result, err := repo.Conn.Exec(context.Background(), query, member.Ime, member.Prezime, member.Dat_uclanjenja, member.Id)

	if err != nil {
		return fmt.Errorf("greška prilikom ažuriranja člana: %v", err)
	}

	// Provera da li je bar jedan red ažuriran
	if result.RowsAffected() == 0 {
		return fmt.Errorf("nema člana sa id-om %d", member.Id)
	}

	return nil
}
