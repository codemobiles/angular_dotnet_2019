import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductResponse } from '../models/product.model';

@Injectable({
  providedIn: 'root'
})
export class NetworkService {

  constructor(private httpClient: HttpClient) { }

  getAllProduct(): Observable<ProductResponse> {
    return this.httpClient.get<ProductResponse>("http://192.168.0.102:5000/api/Product")
  }
}
