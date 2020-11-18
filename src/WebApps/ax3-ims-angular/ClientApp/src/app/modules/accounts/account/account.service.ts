import { Injectable } from '@angular/core';
import {AccountUpdateModel} from '../../../shared/models/account/account-update.model';
import {BaseDataService} from '../../../shared/models/base-data-service';
import {DataService} from '../../../shared/services/data.service';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';
import {AccountModel} from '../../../shared/models/account/account.model';
import {BaseModel} from "../../../shared/models/base-add.model";
import {BaseRequestModel} from "../../../shared/models/base-request.model";
import {LookupRequestModel, LookupResponseModel} from "../../../shared/models/lookup.model";

@Injectable({
  providedIn: 'root'
})
export class AccountService implements BaseDataService {
  private webApiUrl = '';
  constructor(private service: DataService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.webApiUrl = this.configurationService.serverSettings.imsApiClient;
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => this.webApiUrl = this.configurationService.serverSettings.imsApiClient);
    }
  }

  add(addModel: BaseModel) {
    const url = this.webApiUrl + '/api/Account';
    return this.service.post(url, addModel).pipe<boolean>(tap((response: any) => true));
  }

  delete() {
  }

  getById(id: any) {
    const url = this.webApiUrl + '/api/Account/' + id;
    return this.service.get(url).pipe<AccountModel>(tap((response: any) => {
      return response;
    }));
  }

  getList(): Observable<Account[]> {
    const url = this.webApiUrl + '/api/Account';
    return this.service.get(url).pipe<Account[]>(tap((response: any) => {
      return response;
    }));
  }

  update(updateModel: BaseModel) {
    const url = this.webApiUrl + '/api/Account';
    return this.service.putWithId(url, updateModel).pipe<boolean>(tap((response: any) => true));
  }

  dxGetList() {
    const url = this.webApiUrl + '/api/Account/list';
    return this.service.dxGet(url, <BaseRequestModel>{});
  }

  getLookupList(typed: string , parentId?: any) : Observable<LookupResponseModel[]> {
    const url = this.webApiUrl + '/api/Account/filter';
    const requestModel = <LookupRequestModel>{};
    requestModel.typed = typed;
    requestModel.id = parentId;
    return this.service.get(url, requestModel).pipe<LookupResponseModel[]>(tap((response: any) => {
      return response;
    }));
  }
}
