import { Injectable } from '@angular/core';
import {DataService} from '../../../shared/services/data.service';
import {Observable} from 'rxjs';
import {AccountTypes} from '../../../shared/models/account-types.model';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {tap} from 'rxjs/operators';
import {BaseAddModel} from '../../../shared/models/base-add.model';
import {BaseUpdateModel} from '../../../shared/models/base-update.model';
import {LookupRequestModel, LookupResponseModel} from '../../../shared/models/lookup.model';

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

  add(addModel: BaseAddModel) {
  }

  delete() {
  }

  getById(id: any) {
  }

  update(updateModel: BaseUpdateModel) {
  }
}
