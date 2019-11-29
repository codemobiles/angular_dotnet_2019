import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NetworkService } from 'src/app/services/network.service';

@Component({
  selector: 'app-shop-payment',
  templateUrl: './shop-payment.component.html',
  styleUrls: ['./shop-payment.component.css']
})
export class ShopPaymentComponent {

  @Input("total") totalPayment: number
  @Input("order") orderPayment: string
  @Output("submit_success") submitPayment = new EventEmitter<void>()
  @Output("send_name") sendName = new EventEmitter<string>()

  givenNumber = '0.00';

  constructor(private NetworkService: NetworkService) { }

  public get mChange(): number {
    const cash = Number(this.givenNumber.replace(/,/g, ''));
    const result = cash - this.totalPayment;
    if (result >= 0) {
      return result;
    } else {
      return 0;
    }
  }

  public get isPaidEnough() {
    var given = Number(this.givenNumber);
    if (given > 0 && given >= this.totalPayment) {
      return true;
    }
    return false;
  }

  onClickExact() {
    this.givenNumber = String(this.totalPayment);
  }

  onClickGiven(addGiven: number) {
    this.givenNumber = String(Number(this.givenNumber) + addGiven + '.00');
  }

  onClickReset() {
    this.givenNumber = '0.00';
  }

  onClickSubmit() {
    this.submitPayment.emit();
    this.sendName.emit("tanakorn")
  }


}
