import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class PlaylistService {
  private apiUrl = 'https://localhost:7122'; // Reemplaza con la URL de tu API

  constructor(private http: HttpClient) {}

  getPlaylists(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/api/Playlist`);
  }

  getPlaylistById(playlistId: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/api/Playlist/${playlistId}`);
  }

  createPlaylist(name: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/api/Playlist/`, { name });
  }
}
