import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductResponse } from '../models/product.model';
import { RegisterResponse, LoginResponse } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class NetworkService {

  constructor(private httpClient: HttpClient) { }

  register(data): Observable<RegisterResponse> {
    return this.httpClient.post<RegisterResponse>("http://192.168.0.102:5000/api/auth/register", data)
  }

  login(data): Observable<LoginResponse> {
    return this.httpClient.post<LoginResponse>("http://192.168.0.102:5000/api/auth/login", data)
  }

  getAllProduct(): Observable<ProductResponse> {
    return this.httpClient.get<ProductResponse>("http://192.168.0.102:5000/api/Product")
  }
}
