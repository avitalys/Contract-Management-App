import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

// service is singelton
export class LoginService {
  baseUri = 'https://localhost:8080/api/';

  constructor(private http: HttpClient) { }

  login(model:any){
    return this.http.post(this.baseUri + 'login', model);
  }
}
