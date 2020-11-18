import { Injectable } from '@angular/core';
import {DataService} from '../../../shared/services/data.service';
import {Observable} from 'rxjs';
import {AccountTypes} from '../../../shared/models/account-types.model';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {tap} from 'rxjs/operators';
import {BaseModel} from '../../../shared/models/base-add.model';
import {LookupRequestModel, LookupResponseModel} from '../../../shared/models/lookup.model';
import {BaseDataService} from "../../../shared/models/base-data-service";
import CustomStore from "devextreme/data/custom_store";
import {BaseRequestModel} from "../../../shared/models/base-request.model";

@Injectable({
  providedIn: 'root'
})
export class AccountTypesService implements BaseDataService {
  private webApiUrl = '';
  constructor(private service: DataService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.webApiUrl = this.configurationService.serverSettings.imsApiClient;
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => this.webApiUrl = this.configurationService.serverSettings.imsApiClient);
    }
  }
  getList(): Observable<AccountTypes[]> {
    const url = this.webApiUrl + '/api/AccountType';

    return this.service.get(url).pipe<AccountTypes[]>(tap((response: any) => {
      return response;
    }));
  }
  getLookupList(typed: string): Observable<LookupResponseModel[]> {
    const url = this.webApiUrl + '/api/AccountType/filter';
    const requestModel = <LookupRequestModel>{};
    requestModel.typed = typed;
    return this.service.get(url, requestModel).pipe<LookupResponseModel[]>(tap((response: any) => {
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

  dxGetList(): CustomStore {
    const url = this.webApiUrl + '/api/AccountType/list';
    return this.service.dxGet(url, <BaseRequestModel>{});
  }
}
