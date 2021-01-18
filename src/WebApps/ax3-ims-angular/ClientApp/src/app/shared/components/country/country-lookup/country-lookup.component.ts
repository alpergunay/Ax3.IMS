import { Component, OnInit } from '@angular/core';
import {CountryService} from "../country.service";
import {BaseLookupComponent} from "../../../base/base-lookup.component";

@Component({
  selector: 'app-country-lookup',
  templateUrl: './country-lookup.component.html',
  styleUrls: ['./country-lookup.component.scss']
})
export class CountryLookupComponent extends BaseLookupComponent<string> {
  constructor(service: CountryService) { super (service) }
}
