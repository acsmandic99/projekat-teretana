package infrastructure

import (
	"teretana-app/internal/domain"
)

type Database interface {
	//operacije za bazu
	Close()
	//operacije za clana
	//CreateClan(member *domain.Clan) error
	GetByIDClan(id int) (*domain.Clan, error)
	UpdateClan(member *domain.Clan) error
	/*
		GetAllClans() ([]domain.Clan, error)

		DeleteClanById(id int) error

		//operacije za paket
		CreatePaket(paket *domain.Paket) error
		GetByIDPaket(id int) (*domain.Paket, error)
		DeletePaket(id int) error

		//clanstvo
		CreateClanstvo(clanstvo *domain.Clanstvo) error
		GetByIDClanstvo(id int) (*domain.Clanstvo, error)
		UpdateClanstvo(member *domain.Clanstvo) error
		DeleteClanstvo(id int) error

		//trening
		CreateTrening(trening *domain.Trening) error
		DeleteTrening(id int) error
		GetAllTrening() ([]domain.Trening, error)*/
}
