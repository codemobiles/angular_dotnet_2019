import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  position = ['Cashier', 'Admin'];

  constructor() { }

  ngOnInit() {
  }

  register(form: NgForm) {
    alert(JSON.stringify(form.value))
  }

  checkConfirmPassword(form: NgForm){
    return form.value.password !== 
    form.value.comfirm_password && form.value.comfirm_password !== ''
  }

}
