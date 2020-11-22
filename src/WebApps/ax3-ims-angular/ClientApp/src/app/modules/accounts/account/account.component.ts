import {Component} from '@angular/core';
import {DataGridColumnModel} from '../../../shared/components/page-template/data-grid-column-model';
import {BaseComponent} from '../../../shared/base/base.component';
import {AccountService} from './account.service';
import {NotifyService} from '../../../shared/base/notify.service';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {RemoteOperationsModel} from "../../../shared/components/page-template/remote-operations.model";
import {AddAccountComponent} from "./add-account/add-account.component";

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

  constructor(private accountService: AccountService,
              notifyService: NotifyService,
              modalService: NgbModal,
              configurationService: ConfigurationService) {
    super(accountService, notifyService, modalService, configurationService);
    this.Columns = [
      {caption: 'Saklama Yeri Tipi', dataField: 'storeTypeName'},
      {caption: 'Saklama Yeri', dataField: 'storeName'},
      {caption: 'Şube', dataField: 'storeBranchName'},
      {caption: 'Hesap Tipi', dataField: 'accountTypeName'},
      {caption: 'Yatırım Aracı', dataField: 'investmentToolName'},
      {caption: 'Hesap Adı', dataField: 'accountName'},
      {caption: 'Hesap Numarası', dataField: 'accountNo'}
    ];
    this.modalOptions = {
      backdrop: 'static',
      size: "lg"
    };
  }

  openModalFor(modalType: string, parameters?:any) {
    this.openModal(AddAccountComponent, modalType, parameters);
  }
}
