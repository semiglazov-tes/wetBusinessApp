import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {LoginModel} from "../interfaces/LoginModel";
import {Observable} from "rxjs";
import {HttpResponse} from "../../../common-interfaces/HttpResponse";
import {RegistrationModel} from "../interfaces/RegistrationModel";



@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = "https://localhost:7299/api/Auth/";
  private http:HttpClient;
  constructor(httpClient: HttpClient) {
    this.http = httpClient;
  }
  login = (payload:LoginModel):Observable<HttpResponse<object>> => {
    return  this.http.post<HttpResponse<object>>(this.baseUrl+"login",payload, { withCredentials: true });
  }

  registration = (payload:RegistrationModel ):Observable<HttpResponse<object>> => {
    return this.http.post<HttpResponse<object>>(this.baseUrl+"register",payload, { withCredentials: true });
  }
}
