import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Location } from '@angular/common'
import { NetworkService } from 'src/app/services/network.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  position = ['Cashier', 'Admin'];

  constructor(private location: Location, private networkService: NetworkService) { }

  ngOnInit() {
  }

  register(form: NgForm) {
    this.networkService.register(form.value).subscribe(
      data => {
        this.location.back()
      }
    );
  }

  checkConfirmPassword(form: NgForm) {
    return form.value.password !==
      form.value.comfirm_password && form.value.comfirm_password !== ''
  }

  cancel() {
    this.location.back()
  }

}
