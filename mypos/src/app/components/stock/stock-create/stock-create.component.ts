import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { Location } from '@angular/common';
import { NetworkService } from 'src/app/services/network.service';

@Component({
  selector: 'app-stock-create',
  templateUrl: './stock-create.component.html',
  styleUrls: ['./stock-create.component.css']
})
export class StockCreateComponent implements OnInit {

  mProduct = new Product();
  mImageSrc: String | ArrayBuffer

  constructor(private location: Location, private networkService: NetworkService) { }

  ngOnInit() {
    this.mProduct.stock = 0;
    this.mProduct.price = 0;
  }

  submit() {
    this.networkService.newProduct(this.mProduct).subscribe(
      data => {
        this.location.back();
      }
    );
  }

  cancel() {
    this.location.back();
  }

}
