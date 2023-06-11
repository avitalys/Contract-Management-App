import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { take } from 'rxjs';
import { Address } from 'src/app/_models/address';
import { User } from 'src/app/_models/user';
import { CustomerService } from 'src/app/_services/customer.service';
import { LoginService } from 'src/app/_services/login.service';

@Component({
  selector: 'app-address-edit',
  templateUrl: './address-edit.component.html',
  styleUrls: ['./address-edit.component.css']
})
export class AddressEditComponent implements OnInit {
  @Input() customerDetailsAddress?: Address;
  user: User | null = null;
  
  addressModel : Address = {};

  constructor(private loginService: LoginService, private customerService: CustomerService) { 
    this.loginService.loggedinUser$.pipe(take(1)).subscribe({
      next: user => this.user = user
    })
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.addressModel && this.user) {
      console.log(this.user);
      this.customerService.putCustomerAddress(this.user, this.addressModel).subscribe({
        next: response => {
          console.log(response);
        },
        error: error => console.log(error),
        complete: () => console.log("address update completed")
      });
    }
    
  }
}
