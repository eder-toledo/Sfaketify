import { Component, OnInit } from '@angular/core';
import { PlaylistService } from '../playlist.service';

@Component({
  selector: 'app-playlist-list',
  templateUrl: './playlist-list.component.html',
  styleUrls: ['./playlist-list.component.css'],
})
export class PlaylistListComponent implements OnInit {
  playlists: any[] = [];
  newPlaylistName = '';

  constructor(private playlistService: PlaylistService) {}

  ngOnInit(): void {
    this.loadPlaylists();
  }

  loadPlaylists(): void {
    this.playlistService.getPlaylists().subscribe((data) => {
      this.playlists = data;
    });
  }

  createPlaylist(): void {
    this.playlistService.createPlaylist(this.newPlaylistName).subscribe(() => {
      this.loadPlaylists();
      this.newPlaylistName = '';
    });
  }
}