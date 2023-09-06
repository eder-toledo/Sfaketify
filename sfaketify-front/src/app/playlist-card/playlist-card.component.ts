import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-playlist-card',
  templateUrl: './playlist-card.component.html',
  styleUrls: ['./playlist-card.component.css'],
})
export class PlaylistCardComponent implements OnInit {
  @Input() playlist: any;

  ngOnInit(): void {
  }
}