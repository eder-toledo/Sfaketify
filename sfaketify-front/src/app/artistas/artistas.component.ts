import { Component, OnInit } from '@angular/core';
import { ArtistService } from '../artist.service';

@Component({
  selector: 'app-artistas',
  templateUrl: './artistas.component.html',
  styleUrls: ['./artistas.component.css'],
})
export class ArtistasComponent implements OnInit {
  artistas: any[] = [];

  constructor(private artistService: ArtistService) {}

  ngOnInit(): void {
    this.getArtists();
  }

  getArtists(): void {
    this.artistService.getArtists().subscribe((data) => {
      this.artistas = data;
    });
  }
}