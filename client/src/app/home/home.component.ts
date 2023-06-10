import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LoginService } from '../_services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  subTitle= 'Welcome!';
  customers: any;

  constructor(private http: HttpClient, public loginService: LoginService) {}

  ngOnInit(): void {

    //this.loginService.setUserFromStorage();

  }

}
