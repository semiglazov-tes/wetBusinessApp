import { Component, OnInit } from '@angular/core';
import {NgClass} from "@angular/common";
import {FormBuilder, Validators, FormGroup, ReactiveFormsModule} from "@angular/forms";
import {AuthService} from "../serviсes/AuthServiсe";
import {LoginForm} from "../interfaces/LoginForm";
import {RegistrationForm} from "../interfaces/RegistrationForm";

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
export class AuthComponent implements OnInit {
  isRegistered = false;
  private invalidLogin = true;
  private authService:AuthService;
  private formBuilder:FormBuilder;
  public loginForm!: FormGroup<LoginForm>;
  public registrationForm!: FormGroup<RegistrationForm>;


  constructor(authService:AuthService, formBuilder:FormBuilder) {
    this.authService = authService;
    this.formBuilder = formBuilder;
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.nonNullable.group({
      UserName: ['', Validators.required],
      Password: ['', Validators.required],
    });

    this.registrationForm = this.formBuilder.nonNullable.group({
      UserName: ['', Validators.required],
      Email: ['', Validators.required],
      Password: ['', Validators.required],
    });
  }

  register() {
    this.isRegistered = true;
  }

  login()  {
    this.isRegistered = false;
    }

  onRegistrationSubmit() {
    console.log(this.registrationForm.value)
  }

  onLoginSubmit() {
    console.log(this.loginForm.value)
    if (this.loginForm.valid){

      this.authService.login(this.loginForm.value).subscribe();
    }
  }
}


