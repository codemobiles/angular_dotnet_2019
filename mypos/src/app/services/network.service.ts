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
    return this.httpClient.post<RegisterResponse>(this.registerURL, data)
  }

  login(data): Observable<LoginResponse> {
    return this.httpClient.post<LoginResponse>(this.loginURL, data)
  }

  getAllProduct(): Observable<ProductResponse> {
    return this.httpClient.get<ProductResponse>(this.productURL)
  }

  deleteProduct(id: number): Observable<ProductResponse> {
    return this.httpClient.delete<ProductResponse>(`${this.productURL}/${id}`)
  }
}
