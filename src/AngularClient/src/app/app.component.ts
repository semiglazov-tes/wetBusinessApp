import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {AuthComponent} from "./auth/auth/auth.component";
import {HomeComponentComponent} from "./pages/home/home-component.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
  imports: [RouterOutlet, AuthComponent, HomeComponentComponent]
})
export class AppComponent {
  title = 'AngularClient';
}
