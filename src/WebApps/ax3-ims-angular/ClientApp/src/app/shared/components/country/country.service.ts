import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {tap} from "rxjs/operators";
import CustomStore from "devextreme/data/custom_store";
import {LookupRequestModel, LookupResponseModel} from "../../models/lookup.model";
import {CountryModel} from "../../models/country.model";
import {BaseDataService} from "../../models/base-data-service";
import {ConfigurationService} from "../../services/configuration.service";
import {DataService} from "../../services/data.service";

@Injectable({
  providedIn: 'root'
})
export class CountryService implements BaseDataService {
  private webApiUrl = '';
  constructor(private service: DataService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.webApiUrl = this.configurationService.serverSettings.imsApiClient;
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => this.webApiUrl = this.configurationService.serverSettings.imsApiClient);
    }
  }

  add(addModel: CountryModel): Observable<boolean> {
    return;
  }

  delete() {
  }

  getById(id: any) {

  }

  getList(): Observable<CountryModel[]> {
    return;
  }

  update(updateModel: CountryModel): Observable<boolean> {
    return ;
  }

  dxGetList(): CustomStore {
    return;
  }

  getLookupList(typed: string, parentId?: any): Observable<LookupResponseModel[]> {
    const url = this.webApiUrl + '/api/Country/filter';
    const requestModel = <LookupRequestModel>{};
    requestModel.typed = typed;
    requestModel.id = parentId;
    return this.service.get(url, requestModel).pipe<LookupResponseModel[]>(tap((response: any) => {
      return response;
    }));
  }
}
