import {Component, OnInit, ViewChild} from '@angular/core';
import {DataGridColumnModel} from '../../../shared/components/page-template/data-grid-column-model';
import {PageTemplateComponent} from '../../../shared/components/page-template/page-template.component';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {catchError} from 'rxjs/operators';
import {Observable} from 'rxjs';
import {StoreTypesService} from './store-types.service';
import {StoreType} from '../../../shared/models/store-type.model';

@Component({
  selector: 'app-store-types',
  templateUrl: './store-types.component.html',
  styleUrls: ['./store-types.component.scss']
})
export class StoreTypesComponent implements OnInit {Columns: DataGridColumnModel[] = [];
  @ViewChild(PageTemplateComponent) pageTemplate: PageTemplateComponent;
  errorReceived: boolean;
  storeTypes: StoreType[];
  DataSource: any;
  constructor(private service: StoreTypesService, private configurationService: ConfigurationService) {
    this.Columns = [
      {caption: 'Kod', dataField: 'code'},
      {caption: 'Açıklama', dataField: 'name'},
    ];
  }

  ngOnInit(): void {
    if (this.configurationService.isReady) {
      this.getStoreTypes();
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.getStoreTypes();
      });
    }
  }

  getStoreTypes() {
    this.errorReceived = false;
    this.service.getList()
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(storeTypes => {
        this.storeTypes = storeTypes;
        this.DataSource = storeTypes;
      });
  }
  private handleError(error: any) {
    this.errorReceived = true;
    return Observable.throw(error);
  }
}
