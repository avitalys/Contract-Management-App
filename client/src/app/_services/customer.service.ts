import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { LoginService } from './login.service';
import { Customer } from '../_models/customer';
import { User } from '../_models/user';
import { take, map, BehaviorSubject } from 'rxjs';
import { Address } from '../_models/address';

@Injectable({
  providedIn: 'root'
})

export class CustomerService {
  baseUrl = environment.apiUrl;

  private customersSource = new BehaviorSubject<Customer[] | null>(null);
  public readonly customers$ = this.customersSource.asObservable();

  user: User | undefined;

  constructor(private http: HttpClient, private loginService: LoginService) { 
    this.loginService.loggedinUser$.subscribe({
      next: user => {
        //console.log(user);
        if (!user) {
          this.clearCustomers();
        }
      }
    })
  }

  getCustomer(user : User) {
    return this.http.get<Customer>(this.baseUrl + 'customers/' + user.id)
  }
  
  getCustomers() {
    return this.http.get(this.baseUrl + 'customers')
    // .pipe(
    //   map((response) => {
    //     const list = response;
    //     console.log(response)
    //     if (response) {
    //       this.customersSource.next(response);
    //     }
    //     return response;
    //   })
    // )
  }

  clearCustomers(){
    this.customersSource.next(null);
  }

  putCustomerAddress(user: User, newAddress: Address) {
    return this.http.put<Customer>(this.baseUrl + 'customers/' + user.id, newAddress);
  }
}
