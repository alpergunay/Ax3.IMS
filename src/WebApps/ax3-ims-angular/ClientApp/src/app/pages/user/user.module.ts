import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user.component';
import {RouterModule} from "@angular/router";
import {DxButtonModule} from "devextreme-angular";
import {CountryModule} from "../../shared/components/country/country.module";
import {CurrencyModule} from "../../shared/components/currency/currency.module";


@NgModule({
  declarations: [UserComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: UserComponent,
      }
    ]),
    DxButtonModule,
    CountryModule,
    CurrencyModule
  ]
})
export class UserModule { }
