import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {NgClass} from "@angular/common";
import {FormBuilder, Validators, FormGroup, ReactiveFormsModule} from "@angular/forms";
import {AuthService} from "../serviсes/AuthServiсe";
import {LoginForm} from "../interfaces/LoginForm";
import {RegistrationForm} from "../interfaces/RegistrationForm";
import {LoginModel} from "../interfaces/LoginModel";
import {RegistrationModel} from "../interfaces/RegistrationModel";

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
  private router: Router;


  constructor(authService:AuthService, formBuilder:FormBuilder, router:Router) {
    this.authService = authService;
    this.formBuilder = formBuilder;
    this.router = router;
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.nonNullable.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
    });

    this.registrationForm = this.formBuilder.nonNullable.group({
      userName: ['', Validators.required],
      userEmail: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  register() {
    this.isRegistered = false;
  }

  login()  {
    this.isRegistered = true;
    }

  onRegistrationSubmit() {
    console.log(this.registrationForm.value);
    console.log(this.registrationForm.valid);
    console.log(this.registrationForm.errors);
    if (this.registrationForm.valid){
      const registrationPayload = (this.registrationForm.value) as RegistrationModel;

      this.authService.registration(registrationPayload).subscribe({
          next: (data) => {
            console.log(data.statusCode);
            this.isRegistered = true;
          },
          error: (e) => console.error(e)
        }
      );
    }
  }

  onLoginSubmit() {
    console.log(this.loginForm.value);
    if (this.loginForm.valid){
      const loginPayload = (this.loginForm.value) as LoginModel;

      this.authService.login(loginPayload).subscribe({
          next: (data) => {
            console.log(data.statusCode);
            this.router.navigate(['/main']);
          },
          error: (e) => console.error(e)
        }
      );
    }
  }
}

