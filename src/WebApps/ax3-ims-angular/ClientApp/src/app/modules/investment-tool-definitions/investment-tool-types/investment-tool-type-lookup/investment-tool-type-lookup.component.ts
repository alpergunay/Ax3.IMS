import { Component } from '@angular/core';
import {BaseLookupComponent} from "../../../../shared/base/base-lookup.component";
import {InvestmentToolTypesService} from "../investment-tool-types.service";

@Component({
  selector: 'app-investment-tool-type-lookup',
  templateUrl: './investment-tool-type-lookup.component.html',
  styleUrls: ['./investment-tool-type-lookup.component.scss']
})
export class InvestmentToolTypeLookupComponent extends BaseLookupComponent<number> {
  constructor(service: InvestmentToolTypesService) { super (service) }
}
