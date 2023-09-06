import { Component, OnInit } from '@angular/core';
import { PlaylistService } from '../playlist.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-playlist-detail',
  templateUrl: './playlist-detail.component.html',
  styleUrls: ['./playlist-detail.component.css'],
})
export class PlaylistDetailComponent implements OnInit {
  playlist: any;

  constructor(
    private playlistService: PlaylistService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const playlistId = this.route.snapshot.paramMap.get('id');
    this.loadPlaylistDetails(Number(playlistId));
  }

  loadPlaylistDetails(playlistId: number): void {
    this.playlistService.getPlaylistById(playlistId).subscribe((data) => {
      this.playlist = data;
    });
  }
}