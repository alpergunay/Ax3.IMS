import {Component, EventEmitter, Input, OnChanges, Output} from '@angular/core';
import {AccountService} from "../account.service";
import DataSource from "devextreme/data/data_source";
import CustomStore from "devextreme/data/custom_store";
import {AccountLookupModel} from "../../../../shared/models/account/account-lookup.model";


@Component({
  selector: 'app-account-lookup',
  templateUrl: './account-lookup.component.html',
  styleUrls: ['./account-lookup.component.scss']
})
export class AccountLookupComponent {
  groupColumnName = "accountTypeName";
  @Input() selectedValue = <string>{};
  @Input() selectedText = '';
  @Input() investmentToolId = "";
  @Output() selectedData: EventEmitter<string> = new EventEmitter<string>();
  @Output() selected: EventEmitter<string> = new EventEmitter<string>();
  dataSource: any;
  parentId?: any;
  oldInvestmentToolId: string = "";

  constructor(private service: AccountService) {
  }

  getDisplayExpr(item) {
    if (!item) {
      return "";
    }
    return item.accountName + " (" + item.balance.toLocaleString() + " " + item.investmentToolCode + " )";
  }

  ngOnInit(): void {
    this.loadData();
  }

  ngOnChanges(): void {
    if (this.oldInvestmentToolId !== undefined && this.oldInvestmentToolId !== "" && this.oldInvestmentToolId !== this.investmentToolId) {
      setTimeout(() => {
        this.selectedValue = "";
        this.selectedText = "";
      }, 0);
      //this.onChange();
    }
    if (this.oldInvestmentToolId !== this.investmentToolId) {
      this.loadData();
    }
    this.oldInvestmentToolId = this.investmentToolId;
  }

  loadData() {
    const serviceIns = this.service;
    const selectedItemId = this.selectedValue;
    const selectedItemText = this.selectedText;
    const selectedParentId = this.parentId;
    const investmentTool = this.investmentToolId

    this.dataSource = new DataSource({
      store: new CustomStore({
        load: function (loadOptions) {
          const typed = loadOptions.searchValue == null ? '' : loadOptions.searchValue;
          return serviceIns.getLookupList(typed, selectedParentId, investmentTool).toPromise().then(response => {
            return response;
          });
        },
        byKey: function (key) {
          const selectedItemList = [];
          return new Promise<AccountLookupModel[]>((resolve, reject) => {
            resolve(selectedItemList);
          }).then(selectedItemList => {
            return selectedItemList;
          });
        }
      }),
      map: function (item) {
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
  reloadLookupData() {
    this.dataSource.load();
  }
}
