import { Component } from '@angular/core';
import {NgClass} from "@angular/common";

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [
    NgClass
  ],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.scss'
})
export class AuthComponent {
  isRegistered = false;

  register() {
    this.isRegistered = true;
  }

  login() {
    this.isRegistered = false;
  }
}
