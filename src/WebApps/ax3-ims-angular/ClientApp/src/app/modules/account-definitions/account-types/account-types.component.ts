import {Component, OnInit, ViewChild} from '@angular/core';
import {DataGridColumnModel} from '../../../shared/components/page-template/data-grid-column-model';
import {PageTemplateComponent} from '../../../shared/components/page-template/page-template.component';
import {AccountTypesService} from './account-types.service';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {catchError} from 'rxjs/operators';
import {throwError} from 'rxjs';
import {IAccountTypes} from '../../../shared/models/account-types';

@Component({
  selector: 'app-account-types',
  templateUrl: './account-types.component.html',
  styleUrls: ['./account-types.component.scss']
})
export class AccountTypesComponent implements OnInit {
  Columns: DataGridColumnModel[] = [];
  @ViewChild(PageTemplateComponent) pageTemplate: PageTemplateComponent;
  errorReceived: boolean;
  accountTypes: IAccountTypes[];
  DataSource: any;
  constructor(private service: AccountTypesService, private configurationService: ConfigurationService) {
    this.Columns = [
      {caption: 'Kod', dataField: 'code'},
      {caption: 'Açıklama', dataField: 'name'},
    ];
  }

  ngOnInit(): void {
    if (this.configurationService.isReady) {
      this.getAccountTypes();
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.getAccountTypes();
      });
    }
  }

  getAccountTypes() {
    this.errorReceived = false;
    this.service.getList()
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(accountTypes => {
        this.accountTypes = accountTypes;
        this.DataSource = accountTypes;
      });
  }
  private handleError(error: any) {
    this.errorReceived = true;
    return throwError(error);
  }
}
