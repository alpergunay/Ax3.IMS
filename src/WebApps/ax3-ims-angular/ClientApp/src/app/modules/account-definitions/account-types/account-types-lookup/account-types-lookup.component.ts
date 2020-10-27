import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import DataSource from 'devextreme/data/data_source';
import {AccountTypesService} from '../account-types.service';
import CustomStore from 'devextreme/data/custom_store';
import {LookupRequestModel, LookupResponseModel} from '../../../../shared/models/lookup.model';

@Component({
  selector: 'app-account-types-lookup',
  templateUrl: './account-types-lookup.component.html',
  styleUrls: ['./account-types-lookup.component.scss']
})
export class AccountTypesLookupComponent implements OnInit {
  @Input() selectedValue = 0;
  @Input() selectedText = '';
  @Output() selected: EventEmitter<number> = new EventEmitter<number>();
  dataSource: DataSource;
  constructor(private service: AccountTypesService) { }

  ngOnInit(): void {
    this.loadData();
  }
  loadData() {
    const serviceIns = this.service;
    const selectedItemId = this.selectedValue;
    const selectedItemText = this.selectedText;

    this.dataSource = new DataSource({
      store: new CustomStore({
        load: function (loadOptions) {
          const typed = loadOptions.searchValue == null ? '' : loadOptions.searchValue;
          return serviceIns.getLookupList(typed).toPromise().then(response => {
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
            resolve(selectedItemList); }).then(selectedItemList => {
              return selectedItemList;
            });
        }
      })
    });
  }
  onChange() {
    this.selected.emit(this.selectedValue);
  }
}

