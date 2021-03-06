import { Component } from '@angular/core';
import {BaseLookupComponent} from "../../../shared/base/base-lookup.component";
import {AccountTypesService} from "../account-types/account-types.service";

@Component({
  selector: 'app-account-type-lookup',
  templateUrl: './account-type-lookup.component.html',
  styleUrls: ['./account-type-lookup.component.scss']
})
export class AccountTypeLookupComponent extends BaseLookupComponent<number> {
  constructor(service: AccountTypesService) { super (service) }
}
