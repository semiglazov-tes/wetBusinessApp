import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import {LoginModel} from "../interfaces/LoginModel";

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = "https://localhost:7299/api/Auth/login";
  private http:HttpClient;
  constructor(httpClient: HttpClient) {
    this.http = httpClient;
  }
  login = (payload:LoginModel ) => {
    return this.http.post(this.baseUrl,payload, { withCredentials: true });
  }
}
