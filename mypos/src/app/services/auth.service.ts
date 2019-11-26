import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private router: Router) { }

  isLogin() {
    return localStorage.getItem(environment.keyLocalAuthenInfo) !== null
  }

  logout() {
    // localStorage.removeItem("xxxxxxx");
    localStorage.clear();
    this.router.navigate(["/login"])
  }
}
