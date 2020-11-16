import {Component} from '@angular/core';
import {BaseComponent} from "../../../shared/base/base.component";
import {DataGridColumnModel} from "../../../shared/components/page-template/data-grid-column-model";
import {RemoteOperationsModel} from "../../../shared/components/page-template/remote-operations.model";
import {NotifyService} from "../../../shared/base/notify.service";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ConfigurationService} from "../../../shared/services/configuration.service";
import {StoreBranchService} from "./store-branch.service";
import {AddStoreBranchComponent} from "./add-store-branch/add-store-branch.component";

@Component({
  selector: 'app-store-branches',
  templateUrl: './store-branches.component.html',
  styleUrls: ['./store-branches.component.scss']
})
export class StoreBranchesComponent extends BaseComponent {
  Columns: DataGridColumnModel[] = [];
  remoteOperations = <RemoteOperationsModel>{
    enable: true,
    paging: true,
    scrollingMode: 'false'
  };

  constructor(private storeBranchService: StoreBranchService,
              notifyService: NotifyService,
              modalService: NgbModal,
              configurationService: ConfigurationService) {
    super(storeBranchService, notifyService, modalService, configurationService);
    this.Columns = [
      {caption: 'Saklama Yeri Tipi', dataField: 'storeTypeName'},
      {caption: 'Saklama Yeri', dataField: 'storeName'},
      {caption: 'Şube İsmi', dataField: 'name'}
    ];
  }

  openModalFor(modalType: string, parameters?:any) {
    this.openModal(AddStoreBranchComponent, modalType, parameters);
  }
}
