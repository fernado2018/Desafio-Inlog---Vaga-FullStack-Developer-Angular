import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { environment as env } from '../../../environments/environment';
import L from 'leaflet';
import { Router } from '@angular/router';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Localizacao } from '@app/models/Localizacao';
@Component({
  selector: 'app-mapa',
  templateUrl: './mapa.component.html',
  styleUrl: './mapa.component.scss',
})
export class MapaComponent implements OnInit, OnDestroy {
  mapa: any;
  latlng: any;
  nome: any;

  constructor(@Inject(MAT_DIALOG_DATA) public data: string) {
    this.latlng = data;
  }

  ngOnInit(): void {
    this.renderizarMapa();
  }

  ngOnDestroy(): void {
    this.mapa.invalidateSize();
  }

  renderizarMapa() {
    const carroIcon = L.icon({
      iconUrl:
        'https://fonts.gstatic.com/s/i/materialicons/directions_car/v6/24px.svg',
      iconSize: [32, 32],
      iconAnchor: [16, 32],
      popupAnchor: [0, -32],
    });

    const latlng = this.latlng.split(',');
    this.mapa = L.map('mapa-local').setView(latlng, 13);
    L.tileLayer(env.MAPA_TILE_LAYER, { maxZoom: 10 }).addTo(this.mapa);
    L.marker(latlng, { icon: carroIcon }).addTo(this.mapa).bindPopup('');
    L.circle(latlng, {
      color: 'orange',
      fillColor: 'light-blue',
      fillOpacity: 0.35,
      radius: 1000,
    }).addTo(this.mapa);
  }
}
