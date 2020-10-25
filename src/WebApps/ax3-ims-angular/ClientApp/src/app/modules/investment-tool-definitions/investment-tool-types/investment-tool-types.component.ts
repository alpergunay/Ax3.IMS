import {Component, OnInit, ViewChild} from '@angular/core';
import {DataGridColumnModel} from '../../../shared/components/page-template/data-grid-column-model';
import {PageTemplateComponent} from '../../../shared/components/page-template/page-template.component';
import {IInvestmentToolType} from '../../../shared/models/investment-tool-type';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {InvestmentToolTypesService} from './investment-tool-types.service';
import {catchError} from 'rxjs/operators';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-investment-tool-types',
  templateUrl: './investment-tool-types.component.html',
  styleUrls: ['./investment-tool-types.component.scss']
})
export class InvestmentToolTypesComponent implements OnInit {
  Columns: DataGridColumnModel[] = [];
  @ViewChild(PageTemplateComponent) pageTemplate: PageTemplateComponent;
  errorReceived: boolean;
  investmentToolTypes: IInvestmentToolType[];
  DataSource: any;
  constructor(private service: InvestmentToolTypesService, private configurationService: ConfigurationService) {
    this.Columns = [
      {caption: 'Kod', dataField: 'code'},
      {caption: 'Açıklama', dataField: 'name'},
    ];
  }

  ngOnInit(): void {
    if (this.configurationService.isReady) {
      this.getInvestmentToolTypes();
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.getInvestmentToolTypes();
      });
    }
  }

  getInvestmentToolTypes() {
    this.errorReceived = false;
    this.service.getList()
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(investmentToolTypes => {
        this.investmentToolTypes = investmentToolTypes;
        this.DataSource = investmentToolTypes;
      });
  }
  private handleError(error: any) {
    this.errorReceived = true;
    return Observable.throw(error);
  }
}
