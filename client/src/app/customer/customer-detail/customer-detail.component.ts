import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs';
import { Address } from 'src/app/_models/address';
import { Customer } from 'src/app/_models/customer';
import { User } from 'src/app/_models/user';
import { CustomerService } from 'src/app/_services/customer.service';
import { LoginService } from 'src/app/_services/login.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {
  user: User | null = null;
  customer: Customer | undefined;
  editMode: boolean = false;

  constructor(private customerService: CustomerService, private loginService: LoginService) { 
    this.loginService.loggedinUser$.pipe(take(1)).subscribe({
      next: user => this.user = user
    })
  }

  ngOnInit(): void {
    this.loadCustomer();
  }

  loadCustomer() {
    if (!this.user) return;
    this.customerService.getCustomer(this.user).subscribe({
      next: customer => this.customer = customer
    })

  }

  toggleEditMode()
  {
    this.editMode = !this.editMode;
  }

  handleSuccessEdit(event: Address){
    if (this.customer)
      this.customer.address = event;
    this.toggleEditMode();
  }
}
