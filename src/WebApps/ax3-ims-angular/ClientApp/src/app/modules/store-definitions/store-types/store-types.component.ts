import {Component, ViewChild} from '@angular/core';
import {DataGridColumnModel} from '../../../shared/components/page-template/data-grid-column-model';
import {PageTemplateComponent} from '../../../shared/components/page-template/page-template.component';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {StoreTypesService} from './store-types.service';
import {StoreType} from '../../../shared/models/store-type.model';
import {RemoteOperationsModel} from "../../../shared/components/page-template/remote-operations.model";
import {BaseComponent} from "../../../shared/base/base.component";
import {NotifyService} from "../../../shared/base/notify.service";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-store-types',
  templateUrl: './store-types.component.html',
  styleUrls: ['./store-types.component.scss']
})
export class StoreTypesComponent extends BaseComponent{
  Columns: DataGridColumnModel[] = [];
  remoteOperations = <RemoteOperationsModel>{
    enable: true,
    paging: true,
    scrollingMode: 'false'
  };
  @ViewChild(PageTemplateComponent) pageTemplate: PageTemplateComponent;
  constructor(private storeTypeService: StoreTypesService,
              notifyService: NotifyService,
              modalService: NgbModal,
              configurationService: ConfigurationService) {
    super(storeTypeService, notifyService, modalService, configurationService);
    this.Columns = [
      {caption: 'Kod', dataField: 'code'},
      {caption: 'Açıklama', dataField: 'name'},
    ];
  }
}
