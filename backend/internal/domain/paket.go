package domain

type Paket struct {
	ID    int     `json:"id"`
	Naziv string  `json:"naziv"`
	Cena  float64 `json:"cena"`
}
