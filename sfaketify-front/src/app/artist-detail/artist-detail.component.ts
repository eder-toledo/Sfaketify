import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArtistService } from '../artist.service';

@Component({
  selector: 'app-artist-detail',
  templateUrl: './artist-detail.component.html',
  styleUrls: ['./artist-detail.component.css'],
})
export class ArtistDetailComponent implements OnInit {
  artist: any;

  constructor(
    private route: ActivatedRoute,
    private artistService: ArtistService
  ) {}

  ngOnInit(): void {
    this.getArtistDetails();
  }

  getArtistDetails(): void {
    const artistId = this.route.snapshot.paramMap.get('id');
    this.artistService.getArtistDetails(Number(artistId)).subscribe((data) => {
      this.artist = data;
    });
  }
}