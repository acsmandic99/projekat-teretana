package main

import (
	"log"
	"net/http"
	handler "teretana-app/internal/handlers"
	"teretana-app/internal/infrastructure"
	service "teretana-app/internal/services"

	"github.com/gorilla/mux"
)

func main() {
	// Inicijalizacija repozitorijuma i servisa
	repo, err := infrastructure.NewDatabase() // Ovde dodajte vašu konekciju
	if err != nil {
		log.Fatal(err)
	}
	clanService := service.NewClanService(repo)
	clanHandler := handler.NewClanHandler(clanService)

	r := mux.NewRouter()

	r.HandleFunc("/clan/{id}", clanHandler.GetClanByID).Methods("GET")
	r.HandleFunc("/clan", clanHandler.UpdateClan).Methods("PUT")

	http.ListenAndServe(":8080", r)

}
