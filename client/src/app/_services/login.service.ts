import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

// service is singelton
export class LoginService {
  baseUri = environment.apiUrl;
  
  private loggedinUserSource = new BehaviorSubject<User | null>(null);
  public readonly loggedinUser$ = this.loggedinUserSource.asObservable();

  constructor(private http: HttpClient) { }

  setUserFromStorage() {
    const userString = localStorage.getItem('user');
    if (!userString) return;

    const user: User = JSON.parse(userString);
    this.loggedinUserSource.next(user);
  }

  login(model: any) {
    return this.http.post<User>(this.baseUri + 'login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.loggedinUserSource.next(user);
        }
      })
    )
  }

  logout() {
    localStorage.removeItem('user');
    this.loggedinUserSource.next(null);
  }
}
