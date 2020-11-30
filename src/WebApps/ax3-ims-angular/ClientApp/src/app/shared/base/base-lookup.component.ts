import {Component, EventEmitter, Input, OnInit, Output} from "@angular/core";
import {BaseDataService} from "../models/base-data-service";
import DataSource from "devextreme/data/data_source";
import CustomStore from "devextreme/data/custom_store";
import {LookupResponseModel} from "../models/lookup.model";

@Component({
  template: ''
})
export abstract class BaseLookupComponent<T> implements OnInit {
  @Input() selectedValue = <T>{};
  @Input() selectedText = '';
  @Output() selected: EventEmitter<T> = new EventEmitter<T>();
  dataSource: any;
  parentId?: any;
  groupColumnName: string;
  protected constructor(private service: BaseDataService) {
  }

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    const serviceIns = this.service;
    const selectedItemId = this.selectedValue;
    const selectedItemText = this.selectedText;
    const selectedParentId = this.parentId;
    const groupColumnName = this.groupColumnName;

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
          const selectedItem = <LookupResponseModel>{};
          selectedItem.id = selectedItemId;
          selectedItem.name = selectedItemText;
          selectedItemList[0] = selectedItem;

          return new Promise<LookupResponseModel[]>((resolve, reject) => {
            resolve(selectedItemList);
          }).then(selectedItemList => {
            return selectedItemList;
          });
        }
      }),
      group: groupColumnName
    });
  }

  onChange() {
    this.selected.emit(this.selectedValue);
  }
}
