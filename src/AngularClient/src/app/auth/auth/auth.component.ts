//@ts-nocheck
import { Component } from '@angular/core';
import {NgClass} from "@angular/common";
import {ReactiveFormsModule, FormGroup, FormControl, Validators} from "@angular/forms";
import {AuthService} from "../serviсes/AuthServiсe";



@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [
    NgClass,
    ReactiveFormsModule
  ],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.scss'
})
export class AuthComponent {
  isRegistered = false;
  private invalidLogin = true;
  private authService:AuthService;


  constructor(authService:AuthService) {
    this.authService = authService;
  }

  register() {
    this.isRegistered = true;
  }

  login = ( ) => {
    this.isRegistered = false;
    }

  registrationForm= new FormGroup({
    name: new FormControl(),
    email: new FormControl(),
    password: new FormControl()
  })

  onRegistrationSubmit() {
    console.log(this.registrationForm.value)
  }

  loginForm= new FormGroup({
    username: new FormControl(null,Validators.required),
    password: new FormControl(null,Validators.required)
  })

  onLoginSubmit() {
    console.log(this.loginForm.value)
    if (this.loginForm.valid){

      this.authService.login(this.loginForm.value).subscribe();
    }
  }
}


