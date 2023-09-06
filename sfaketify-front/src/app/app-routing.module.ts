import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PlaylistListComponent } from './playlist-list/playlist-list.component';
import { PlaylistDetailComponent } from './playlist-detail/playlist-detail.component'; // Crea este componente para mostrar las canciones de una playlist
import { ArtistasComponent } from './artistas/artistas.component';
import { ArtistDetailComponent } from './artist-detail/artist-detail.component';

const routes: Routes = [
  { path: '', component: PlaylistListComponent },
  { path: 'playlists', component: PlaylistListComponent },
  { path: 'playlist/:id', component: PlaylistDetailComponent },
  { path: 'artistas', component: ArtistasComponent },
  { path: 'artist/:id', component: ArtistDetailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
