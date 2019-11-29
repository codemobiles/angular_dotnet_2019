import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { NetworkService } from 'src/app/services/network.service';
import { Location } from '@angular/common'
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-stock-edit',
  templateUrl: './stock-edit.component.html',
  styleUrls: ['./stock-edit.component.css']
})
export class StockEditComponent implements OnInit {

  mProduct: Product = null;
  imageSrc: String | ArrayBuffer = null

  constructor(private activateRoute: ActivatedRoute,
    private location: Location, private networkService: NetworkService) { }

  ngOnInit() {
      this.activateRoute.params.subscribe(
        params => {
          //  'stock/edit/:id'
          // console.log(params.id);
          this.feedData(params.id)
        }
      );
  }

  feedData(id: number) {
    this.networkService.getProduct(id).subscribe(
      data => {
        data.result.image = `${this.networkService.productImageURL}/${data.result.image}`
        this.mProduct = data.result
      }
    );
  }

  submit() {
    this.networkService.editProduct(this.mProduct, this.mProduct.productId).subscribe(
      data => {
        this.location.back();
      }
    );
  }

  cancel() {
    this.location.back();
  }

  onUploadImage(event) {
    const metaImage = event.target.files[0];
    if (metaImage) {
      const reader = new FileReader();
      reader.readAsDataURL(metaImage);
      reader.onload = () => {
        this.imageSrc = reader.result;
        this.mProduct.image = metaImage;
      };
    }
  }

}
