import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  title = 'Customers Management App';
  subTitle= 'Welcome!';
  customers: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:8080/api/customers').subscribe({
      next: response => this.customers = response,
      error: error => alert(error),
      complete: () => console.log('GET Request Completed')
    });
  }

}
