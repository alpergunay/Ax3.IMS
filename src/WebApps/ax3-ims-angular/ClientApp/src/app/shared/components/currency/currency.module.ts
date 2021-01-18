import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CurrencyComponent } from './currency.component';
import { CurrencyLookupComponent } from './currency-lookup/currency-lookup.component';
import {DxLookupModule} from "devextreme-angular";



@NgModule({
  declarations: [CurrencyComponent, CurrencyLookupComponent],
  exports: [
    CurrencyLookupComponent
  ],
  imports: [
    CommonModule,
    DxLookupModule
  ]
})
export class CurrencyModule { }
