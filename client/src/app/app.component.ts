import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LoginService } from './_services/login.service';
import { User } from './_models/user';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  subTitle= 'Welcome!';
  customers: any;

  constructor(private http: HttpClient, public loginService: LoginService) {}

  ngOnInit(): void {

    this.loginService.setUserFromStorage();

    this.loginService.loggedinUser$.subscribe({
      next: user => user ? this.getCustomers() : this.clearCustomers(),
      error: error => alert(error)
    })
  }

  getCustomers() {
    this.http.get('https://localhost:8080/api/customers').subscribe({
      next: response => this.customers = response,
      error: error => alert(error),
      complete: () => console.log('GET Request Completed')
    });
  }

  clearCustomers(){
    this.customers = [];
  }

}
