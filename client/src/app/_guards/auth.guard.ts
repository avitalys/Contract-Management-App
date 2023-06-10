import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Observable, map } from 'rxjs';
import { LoginService } from '../_services/login.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private loginService: LoginService) {}

  canActivate(): Observable<boolean> {
    return this.loginService.loggedinUser$.pipe(
      map(user => { return !!user })
    )
  }
}
