import { Injectable } from '@angular/core';
import {DataService} from '../../../shared/services/data.service';
import {Observable} from 'rxjs';
import {IAccountTypes} from '../../../shared/models/account-types';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {tap} from 'rxjs/operators';

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
  getAccountTypes(): Observable<IAccountTypes[]> {
    const url = this.webApiUrl + '/api/account-types';

    return this.service.get(url).pipe<IAccountTypes[]>(tap((response: any) => {
      return response;
    }));
  }
}
