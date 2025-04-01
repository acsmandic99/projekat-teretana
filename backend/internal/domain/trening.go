package domain

import "time"

type Trening struct {
	Id                  int       `json:"id"`
	Vreme_poc_treninga  time.Time `json:"vreme_poc_treninga"`
	Vreme_kraj_treninga time.Time `json:"vreme_kraj_treninga"`
}
