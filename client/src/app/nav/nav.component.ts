import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  loggedIn = false;

  constructor() { }

  ngOnInit(): void {
  }

  logout(): void {
    this.loggedIn = false;
  }
}
