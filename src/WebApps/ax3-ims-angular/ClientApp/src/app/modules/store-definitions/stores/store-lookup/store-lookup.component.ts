import {Component, Input} from '@angular/core';
import {BaseLookupComponent} from "../../../../shared/base/base-lookup.component";
import {StoreService} from "../store.service";

@Component({
  selector: 'app-store-lookup',
  templateUrl: './store-lookup.component.html',
  styleUrls: ['./store-lookup.component.scss']
})
export class StoreLookupComponent extends BaseLookupComponent<string> {
  @Input() selectedStoreTypeId: number = 0;
  oldStoreTypeId: number = 0;

  constructor(service: StoreService) {
    super (service)
  }

  ngOnChanges(): void {
    if (this.oldStoreTypeId !== undefined && this.oldStoreTypeId !== 0  && this.oldStoreTypeId !== this.selectedStoreTypeId) {
      setTimeout(() => {
        this.selectedValue = "";
        this.selectedText = "";
      }, 0);
      this.onChange();
    }
    if (this.oldStoreTypeId !== this.selectedStoreTypeId) {
      this.parentId = this.selectedStoreTypeId;
      this.loadData();
    }
    this.oldStoreTypeId = this.selectedStoreTypeId;
  }
}



