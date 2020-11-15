import {Component, EventEmitter, Input, OnInit, Output} from "@angular/core";
import {BaseDataService} from "../models/base-data-service";
import {NotifyService} from "./notify.service";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ConfigurationService} from "../services/configuration.service";
import DataSource from "devextreme/data/data_source";
import CustomStore from "devextreme/data/custom_store";
import {LookupResponseModel} from "../models/lookup.model";

@Component({
  template: ''
})
export abstract class BaseLookupComponent implements OnInit {
  @Input() selectedValue = 0;
  @Input() selectedText = '';
  @Output() selected: EventEmitter<number> = new EventEmitter<number>();
  dataSource: DataSource;
  protected constructor(private service: BaseDataService,
                        private notifyService: NotifyService,
                        private modalService: NgbModal,
                        private configurationService: ConfigurationService) {
  }

  ngOnInit(): void {
    if (this.configurationService.isReady) {
      this.loadData();
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.loadData();
      });
    }
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
            resolve(selectedItemList);
          }).then(selectedItemList => {
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
