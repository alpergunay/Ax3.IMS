import {Component} from '@angular/core';
import {StoreTypesService} from '../store-types.service';
import {BaseLookupComponent} from "../../../../shared/base/base-lookup.component";

@Component({
  selector: 'app-store-type-lookup',
  templateUrl: './store-type-lookup.component.html',
  styleUrls: ['./store-type-lookup.component.scss']
})
export class StoreTypeLookupComponent extends BaseLookupComponent<number> {
  constructor(service: StoreTypesService) { super (service) }
}
