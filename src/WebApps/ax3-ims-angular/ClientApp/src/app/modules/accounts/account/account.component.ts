import {Component, ElementRef, Renderer2, ViewChild} from '@angular/core';
import {DataGridColumnModel} from '../../../shared/components/page-template/data-grid-column-model';
import {PageTemplateComponent} from '../../../shared/components/page-template/page-template.component';
import {BaseComponent} from '../../../shared/base/base.component';
import {AccountService} from './account.service';
import {NotifyService} from '../../../shared/base/notify.service';
import {NgbActiveModal, NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {RemoteOperationsModel} from "../../../shared/components/page-template/remote-operations.model";
import {StoreBranchService} from "../../store-definitions/store-branches/store-branch.service";
import {AddStoreBranchComponent} from "../../store-definitions/store-branches/add-store-branch/add-store-branch.component";

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent extends BaseComponent {
  Columns: DataGridColumnModel[] = [];
  remoteOperations = <RemoteOperationsModel>{
    enable: true,
    paging: true,
    scrollingMode: 'false'
  };

  constructor(private accountService: StoreBranchService,
              notifyService: NotifyService,
              modalService: NgbModal,
              configurationService: ConfigurationService) {
    super(accountService, notifyService, modalService, configurationService);
    this.Columns = [
      {caption: 'Saklama Yeri Tipi', dataField: 'storeTypeName'},
      {caption: 'Saklama Yeri', dataField: 'storeName'},
      {caption: 'Şube', dataField: 'storeBranchName'},
      {caption: 'Hesap Tipi', dataField: 'accountTypeName'},
      {caption: 'Yatırım Aracı', dataField: 'investmentToolName'}
    ];
  }

  openModalFor(modalType: string, parameters?:any) {
    this.openModal(AddStoreBranchComponent, modalType, parameters);
  }
}
