// service/clan_service.go
package service

import (
	"teretana-app/internal/domain"
	"teretana-app/internal/infrastructure"
)

type ClanService struct {
	repo infrastructure.Database
}

func NewClanService(repo infrastructure.Database) *ClanService {
	return &ClanService{repo: repo}
}

func (s *ClanService) GetClanByID(id int) (*domain.Clan, error) {
	return s.repo.GetByIDClan(id)
}

func (s *ClanService) UpdateClan(clan *domain.Clan) error {
	return s.repo.UpdateClan(clan)
}
