import { Injectable } from '@angular/core';
import {DataService} from '../../../shared/services/data.service';
import {Observable} from 'rxjs';
import {IAccountTypes} from '../../../shared/models/account-types';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {tap} from 'rxjs/operators';
import {IAddModel} from '../../../shared/models/iadd-model';
import {IUpdateModel} from '../../../shared/models/iupdate-model';
import {LookupRequestModel, LookupResponseModel} from '../../../shared/models/lookupModel';

@Injectable({
  providedIn: 'root'
})
export class AccountTypesService {
  private webApiUrl = '';
  constructor(private service: DataService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.webApiUrl = this.configurationService.serverSettings.imsApiClient;
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => this.webApiUrl = this.configurationService.serverSettings.imsApiClient);
    }
  }
  getList(): Observable<IAccountTypes[]> {
    const url = this.webApiUrl + '/api/AccountType';

    return this.service.get(url).pipe<IAccountTypes[]>(tap((response: any) => {
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

  add(addModel: IAddModel) {
  }

  delete() {
  }

  getById(id: any) {
  }

  update(updateModel: IUpdateModel) {
  }
}
