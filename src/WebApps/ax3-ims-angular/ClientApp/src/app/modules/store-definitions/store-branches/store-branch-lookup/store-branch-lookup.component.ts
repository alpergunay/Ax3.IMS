import {Component, Input, OnInit} from '@angular/core';
import {BaseLookupComponent} from "../../../../shared/base/base-lookup.component";
import {StoreBranchService} from "../store-branch.service";

@Component({
  selector: 'app-store-branch-lookup',
  templateUrl: './store-branch-lookup.component.html',
  styleUrls: ['./store-branch-lookup.component.scss']
})
export class StoreBranchLookupComponent extends BaseLookupComponent<string> {
  @Input() selectedStoreId: string = '';
  oldStoreId: string = '';

  constructor(service: StoreBranchService) {
    super (service)
  }

  ngOnChanges(): void {
    if (this.oldStoreId !== undefined && this.oldStoreId !== ''  && this.oldStoreId !== this.selectedStoreId) {
      setTimeout(() => {
        this.selectedValue = "";
        this.selectedText = "";
      }, 0);
      this.onChange();
    }
    if (this.oldStoreId !== this.selectedStoreId) {
      this.parentId = this.selectedStoreId;
      this.loadData();
    }
    this.oldStoreId = this.selectedStoreId;
  }
}
