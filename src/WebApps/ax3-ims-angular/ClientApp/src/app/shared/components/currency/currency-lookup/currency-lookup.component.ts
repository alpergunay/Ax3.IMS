import { Component, OnInit } from '@angular/core';
import {CurrencyService} from "../currency.service";
import {BaseLookupComponent} from "../../../base/base-lookup.component";

@Component({
  selector: 'app-currency-lookup',
  templateUrl: './currency-lookup.component.html',
  styleUrls: ['./currency-lookup.component.scss']
})
export class CurrencyLookupComponent extends BaseLookupComponent<string> {
  constructor(service: CurrencyService) { super (service) }
}
