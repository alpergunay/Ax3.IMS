import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import CustomStore from "devextreme/data/custom_store";
import {tap} from "rxjs/operators";
import {LookupRequestModel, LookupResponseModel} from "../../models/lookup.model";
import {CurrencyModel} from "../../models/currency.model";
import {InvestmentToolTypeEnumModel} from "../../models/investment-tool-type-enum.model";
import {BaseDataService} from "../../models/base-data-service";
import {ConfigurationService} from "../../services/configuration.service";
import {DataService} from "../../services/data.service";

@Injectable({
  providedIn: 'root'
})
export class CurrencyService implements BaseDataService {
  private webApiUrl = '';
  constructor(private service: DataService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.webApiUrl = this.configurationService.serverSettings.imsApiClient;
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => this.webApiUrl = this.configurationService.serverSettings.imsApiClient);
    }
  }

  add(addModel: CurrencyModel): Observable<boolean> {
    return;
  }

  delete() {
  }

  getById(id: any) {

  }

  getList(): Observable<CurrencyModel[]> {
    return;
  }

  update(updateModel: CurrencyModel): Observable<boolean> {
    return ;
  }

  dxGetList(): CustomStore {
    return;
  }

  getLookupList(typed: string, parentId?: any): Observable<LookupResponseModel[]> {
    const url = this.webApiUrl + '/api/InvestmentTool/filter';
    const requestModel = <LookupRequestModel>{};
    requestModel.typed = typed;
    requestModel.id = InvestmentToolTypeEnumModel.Currency
    return this.service.get(url, requestModel).pipe<LookupResponseModel[]>(tap((response: any) => {
      return response;
    }));
  }
}
