import { Injectable } from '@angular/core';
import {AccountAddModel} from '../../../shared/models/account/account-add.model';
import {AccountUpdateModel} from '../../../shared/models/account/account-update.model';
import {BaseDataService} from '../../../shared/models/base-data-service';
import {DataService} from '../../../shared/services/data.service';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {Observable} from 'rxjs';
import {AccountTypes} from '../../../shared/models/account-types.model';
import {tap} from 'rxjs/operators';
import {Account} from '../../../shared/models/account/account.model';

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

  add(addModel: AccountAddModel) {

  }

  delete() {
  }

  getById(id: any) {
  }

  getList(): Observable<Account[]> {
    const url = this.webApiUrl + '/api/Account';

    return this.service.get(url).pipe<Account[]>(tap((response: any) => {
      return response;
    }));
  }

  update(updateModel: AccountUpdateModel) {
  }

  dxGetList() {
  }

  getLookupList(typed: string) {
  }
}
