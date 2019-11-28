import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductResponse } from '../models/product.model';
import { RegisterResponse, LoginResponse } from '../models/user.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NetworkService {

  private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
  private hostURL = environment.baseAPIURL;  
  private apiURL = `${this.hostURL}`;
  // -----------------------------------------------------
  private loginURL = `${this.apiURL}/auth/login`;
  private registerURL = `${this.apiURL}/auth/register`;
  private productURL = `${this.apiURL}/product`;
  public productImageURL = `${this.apiURL}/product/images`;
  private outOfStockURL = `${this.productURL}/count/out_of_stock`;
  private transactionURL = `${this.apiURL}/transaction`;
  
  constructor(private httpClient: HttpClient) { }

  register(data): Observable<RegisterResponse> {
    return this.httpClient.post<RegisterResponse>("xxxxxxapi/auth/register", data)
  }

  login(data): Observable<LoginResponse> {
    return this.httpClient.post<LoginResponse>("xxxxx/api/auth/login", data)
  }

  getAllProduct(): Observable<ProductResponse> {
    return this.httpClient.get<ProductResponse>("http://192.168.0.102:5000/api/Product")
  }
}
