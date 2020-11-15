import {Component} from '@angular/core';
import {BaseComponent} from '../../../shared/base/base.component';
import {DataGridColumnModel} from '../../../shared/components/page-template/data-grid-column-model';
import {NotifyService} from '../../../shared/base/notify.service';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {StoreService} from './store.service';
import {AddStoreComponent} from './add-store/add-store.component';
import {RemoteOperationsModel} from "../../../shared/components/page-template/remote-operations.model";

@Component({
  selector: 'app-stores',
  templateUrl: './stores.component.html',
  styleUrls: ['./stores.component.scss']
})
export class StoresComponent extends BaseComponent {
  Columns: DataGridColumnModel[] = [];
  remoteOperations = <RemoteOperationsModel>{
    enable: true,
    paging: true,
    scrollingMode: 'false'
  };
  constructor(private storeService: StoreService,
              notifyService: NotifyService,
              modalService: NgbModal,
              configurationService: ConfigurationService) {
    super(storeService, notifyService, modalService, configurationService);
    this.Columns = [
      {caption: 'Saklama Yeri Tipi', dataField: 'storeTypeName'},
      {caption: 'Saklama Yeri', dataField: 'name'},
    ];
  }

  openModalFor(modalType: string, parameters?:any) {
    this.openModal(AddStoreComponent, modalType, parameters);
  }
}
