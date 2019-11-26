import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  login(form: NgForm){
    // alert(JSON.stringify(form.value))
    this.router.navigate(["/stock"]);
  }

}
