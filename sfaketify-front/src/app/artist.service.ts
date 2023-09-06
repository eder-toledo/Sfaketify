import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ArtistService {
  private apiUrl = 'https://localhost:7122'; // Reemplaza con la URL correcta de tu API

  constructor(private http: HttpClient) {}

  getArtists(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/api/Artists`);
  }

  getArtistDetails(artistId: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/api/Artists/${artistId}`);
  }
}