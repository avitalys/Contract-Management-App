import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { Customer } from 'src/app/_models/customer';
import { User } from 'src/app/_models/user';
import { CustomerService } from 'src/app/_services/customer.service';
import { LoginService } from 'src/app/_services/login.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  user: User | null = null;
  customers: any = [];

  constructor(public customerService: CustomerService, private loginService: LoginService) { 
    this.loginService.loggedinUser$.pipe(take(1)).subscribe({
      next: user => {
        this.user = user;
      }
    })
  }

  ngOnInit(): void {
    this.customerService.customers$.subscribe({
      next: response => {
        this.customers = response || [];
      }
    });

    console.log('call getCustomers');
    this.customerService.getCustomers().subscribe({
      next: list => this.customers = list,
      error: error => console.log(error),
      complete: () => console.log('GET Request Completed')
    });
  }

}
