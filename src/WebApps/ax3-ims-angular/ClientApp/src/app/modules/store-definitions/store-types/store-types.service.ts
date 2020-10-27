import { Injectable } from '@angular/core';
import {DataService} from '../../../shared/services/data.service';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';
import {StoreType} from '../../../shared/models/store-type.model';
import {BaseDataService} from '../../../shared/models/base-data-service';
import {BaseAddModel} from '../../../shared/models/base-add.model';
import {BaseUpdateModel} from '../../../shared/models/base-update.model';

@Injectable({
  providedIn: 'root'
})
export class StoreTypesService implements BaseDataService {

  private webApiUrl = '';

  constructor(private service: DataService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.webApiUrl = this.configurationService.serverSettings.imsApiClient;
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => this.webApiUrl = this.configurationService.serverSettings.imsApiClient);
    }
  }
  getList(): Observable<StoreType[]> {
    const url = this.webApiUrl + 'StoreTypes';

    return this.service.get(url).pipe<StoreType[]>(tap((response: any) => {
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
