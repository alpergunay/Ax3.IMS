import {Component} from '@angular/core';
import {DataGridColumnModel} from '../../../shared/components/page-template/data-grid-column-model';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {InvestmentToolTypesService} from './investment-tool-types.service';
import {BaseComponent} from "../../../shared/base/base.component";
import {NotifyService} from "../../../shared/base/notify.service";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-investment-tool-types',
  templateUrl: './investment-tool-types.component.html',
  styleUrls: ['./investment-tool-types.component.scss']
})
export class InvestmentToolTypesComponent extends BaseComponent {
  Columns: DataGridColumnModel[] = [];

  constructor(private investmentToolTypeService: InvestmentToolTypesService,
              notifyService: NotifyService,
              modalService: NgbModal,
              configurationService: ConfigurationService) {
    super(investmentToolTypeService, notifyService, modalService, configurationService);
    this.Columns = [
      {caption: 'Kod', dataField: 'code'},
      {caption: 'Açıklama', dataField: 'name'},
    ];
  }
}
