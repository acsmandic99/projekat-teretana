package domain

import "time"

type Clanstvo struct {
	Id            int       `json:"id"`
	Clan_id       int       `json:"clan_id"`
	Paket_id      int       `json:"paket_id"`
	Paket_naziv   string    `json:"paket_naziv"`
	Datum_pocetka time.Time `json:"datum_pocetka"`
	Datum_kraja   time.Time `json:"datum_kraja"`
}
