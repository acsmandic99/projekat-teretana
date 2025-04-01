package domain

import "time"

type NacinUplate int

const (
	Gotovina NacinUplate = iota // 0
	Kartica                     // 1
)

type Uplata struct {
	ID          int
	DatumUplate time.Time
	nacinUplate NacinUplate
}
