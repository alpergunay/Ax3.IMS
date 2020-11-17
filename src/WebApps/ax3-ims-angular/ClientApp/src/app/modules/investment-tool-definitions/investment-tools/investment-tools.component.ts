import { Component } from '@angular/core';
import {BaseComponent} from "../../../shared/base/base.component";
import {DataGridColumnModel} from "../../../shared/components/page-template/data-grid-column-model";
import {RemoteOperationsModel} from "../../../shared/components/page-template/remote-operations.model";
import {NotifyService} from "../../../shared/base/notify.service";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ConfigurationService} from "../../../shared/services/configuration.service";
import {InvestmentToolsService} from "./investment-tools.service";
import {AddInvestmentToolComponent} from "./add-investment-tool/add-investment-tool.component";

@Component({
  selector: 'app-investment-tools',
  templateUrl: './investment-tools.component.html',
  styleUrls: ['./investment-tools.component.scss']
})
export class InvestmentToolsComponent extends BaseComponent {
  Columns: DataGridColumnModel[] = [];
  remoteOperations = <RemoteOperationsModel>{
    enable: true,
    paging: true,
    scrollingMode: 'false'
  };
  constructor(private investmentToolService: InvestmentToolsService,
              notifyService: NotifyService,
              modalService: NgbModal,
              configurationService: ConfigurationService) {
    super(investmentToolService, notifyService, modalService, configurationService);
    this.Columns = [
      {caption: 'Tip', dataField: 'investmentToolTypeName'},
      {caption: 'Kod', dataField: 'code'},
      {caption: 'Açıklama', dataField: 'name'},
    ];
  }

  openModalFor(modalType: string, parameters?:any) {
    this.openModal(AddInvestmentToolComponent, modalType, parameters);
  }
}
