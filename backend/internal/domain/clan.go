package domain

import "time"

type Clan struct {
	Id             int        `json:"id"`
	Ime            string     `json:"ime"`
	Prezime        string     `json:"prezime"`
	Dat_uclanjenja time.Time  `json:"dat_uclanjenja"`
	Clanstva       []Clanstvo `json:"clanstva"`
	Treninzi       []Trening  `json:"treninzi"`
}
