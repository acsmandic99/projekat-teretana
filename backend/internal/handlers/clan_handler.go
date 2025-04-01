package handler

import (
	"encoding/json"
	"net/http"
	"strconv"
	"teretana-app/internal/domain"
	service "teretana-app/internal/services"

	"github.com/gorilla/mux"
)

type ClanHandler struct {
	service *service.ClanService
}

func NewClanHandler(service *service.ClanService) *ClanHandler {
	return &ClanHandler{service: service}
}

// GetClanByID handler
func (h *ClanHandler) GetClanByID(w http.ResponseWriter, r *http.Request) {
	vars := mux.Vars(r)
	id, err := strconv.Atoi(vars["id"])
	if err != nil {
		http.Error(w, "Invalid clan ID", http.StatusBadRequest)
		return
	}

	clan, err := h.service.GetClanByID(id)
	if err != nil {
		http.Error(w, err.Error(), http.StatusNotFound)
		return
	}

	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(clan)
}

func (h *ClanHandler) UpdateClan(w http.ResponseWriter, r *http.Request) {
	var clan domain.Clan
	err := json.NewDecoder(r.Body).Decode(&clan)
	if err != nil {
		http.Error(w, "Invalid request body", http.StatusBadRequest)
		return
	}

	if err := h.service.UpdateClan(&clan); err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}

	w.WriteHeader(http.StatusOK)
	w.Write([]byte("Clan updated successfully"))
}
