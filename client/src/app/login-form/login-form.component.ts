import { Component, OnInit } from '@angular/core';
import { LoginService } from '../_services/login.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  
  model: any = {};

  constructor(private loginService: LoginService) {

  }

  ngOnInit(): void {
  }

  login() {
    this.loginService.login(this.model).subscribe({
      next: response => {
        console.log(response);
        //TODO: save token, set login state
      },
      error: error => console.log(error)
    });
  }
}
