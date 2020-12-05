import {Component, EventEmitter, Input, Output} from '@angular/core';
import {AccountService} from "../account.service";
import DataSource from "devextreme/data/data_source";
import CustomStore from "devextreme/data/custom_store";
import {AccountLookupModel} from "../../../../shared/models/account/account-lookup.model";


@Component({
  selector: 'app-account-lookup',
  templateUrl: './account-lookup.component.html',
  styleUrls: ['./account-lookup.component.scss']
})
export class AccountLookupComponent  {
  groupColumnName = "accountTypeName";
  @Input() selectedValue = <string>{};
  @Input() selectedText = '';
  @Output() selectedData: EventEmitter<string> = new EventEmitter<string>();
  @Output() selected: EventEmitter<string> = new EventEmitter<string>();
  dataSource: any;
  parentId?: any;
  constructor(private service: AccountService) {
  }
  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    const serviceIns = this.service;
    const selectedItemId = this.selectedValue;
    const selectedItemText = this.selectedText;
    const selectedParentId = this.parentId;

    this.dataSource = new DataSource({
      store: new CustomStore({
        load: function (loadOptions) {
          const typed = loadOptions.searchValue == null ? '' : loadOptions.searchValue;
          return serviceIns.getLookupList(typed, selectedParentId).toPromise().then(response => {
            return response;
          });
        },
        byKey: function (key) {
           const selectedItemList = [];
        //   const selectedItem = <AccountLookupModel>{};
        //   selectedItem.accounts[0].accountId = selectedItemId;
        //   selectedItem.accounts[0].accountName = selectedItemText;
        //   selectedItemList[0] = selectedItem;
        //
           return new Promise<AccountLookupModel[]>((resolve, reject) => {
             resolve(selectedItemList);
           }).then(selectedItemList => {
             return selectedItemList;
           });
         }
      }),
      map: function(item) {
        item.key = item.accountTypeName;
        item.items = item.accounts;
        return item;
      }
    });
  }

  onChange(data: any) {
    this.selectedData.emit(data.component.option("selectedItem"));
    this.selected.emit(this.selectedValue);
  }
}
