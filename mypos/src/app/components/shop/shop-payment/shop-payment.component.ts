import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-shop-payment',
  templateUrl: './shop-payment.component.html',
  styleUrls: ['./shop-payment.component.css']
})
export class ShopPaymentComponent implements OnInit {

  @Input("total") totalPayment: number
  @Input("order") orderPayment: string
  @Output("submit_success") submitPayment = new EventEmitter<void>()
  @Output("send_name") sendName = new EventEmitter<string>()

  constructor() { }

  ngOnInit() {

  }

  onClickSubmit(){
    this.submitPayment.emit()
  }

  onClickTest(){
    this.sendName.emit("tanakorn")
  }

}
