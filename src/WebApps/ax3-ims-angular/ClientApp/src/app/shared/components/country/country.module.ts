import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CountryComponent } from './country.component';
import { CountryLookupComponent } from './country-lookup/country-lookup.component';
import {DxLookupModule} from "devextreme-angular";



@NgModule({
  declarations: [CountryComponent, CountryLookupComponent],
  exports: [
    CountryLookupComponent
  ],
  imports: [
    CommonModule,
    DxLookupModule
  ]
})
export class CountryModule { }
