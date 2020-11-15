import { Injectable } from '@angular/core';
import {DataService} from '../../../shared/services/data.service';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';
import {InvestmentToolType} from '../../../shared/models/investment-tool-type.model';
import {BaseDataService} from '../../../shared/models/base-data-service';
import {BaseModel} from '../../../shared/models/base-add.model';

@Injectable({
  providedIn: 'root'
})
export class InvestmentToolTypesService implements BaseDataService {
  private webApiUrl = '';

  constructor(private service: DataService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.webApiUrl = this.configurationService.serverSettings.imsApiClient;
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => this.webApiUrl = this.configurationService.serverSettings.imsApiClient);
    }
  }
  getList(): Observable<InvestmentToolType[]> {
    const url = this.webApiUrl + 'InvestmentToolType';

    return this.service.get(url).pipe<InvestmentToolType[]>(tap((response: any) => {
      return response;
    }));
  }

  add(addModel: BaseModel) {
  }

  delete() {
  }

  getById(id: any) {
  }

  update(updateModel: BaseModel) {
  }

  dxGetList() {
  }

  getLookupList(typed: string) {
  }
}
