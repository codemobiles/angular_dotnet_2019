import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/authen/login/login.component';
import { RegisterComponent } from './components/authen/register/register.component';
import { FormsModule } from '@angular/forms';
import { StockHomeComponent } from './components/stock/stock-home/stock-home.component';
import { StockCreateComponent } from './components/stock/stock-create/stock-create.component';
import { StockEditComponent } from './components/stock/stock-edit/stock-edit.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { MenuComponent } from './components/shared/menu/menu.component'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http'
import { NetworkService } from './services/network.service';
import { JwtInterceptor } from './services/jwt.interceptor';
import { ShopPaymentComponent } from './components/shop/shop-payment/shop-payment.component';
import { ShopHomeComponent } from './components/shop/shop-home/shop-home.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    StockHomeComponent,
    StockCreateComponent,
    StockEditComponent,
    FooterComponent,
    HeaderComponent,
    MenuComponent,
    ShopPaymentComponent,
    ShopHomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

