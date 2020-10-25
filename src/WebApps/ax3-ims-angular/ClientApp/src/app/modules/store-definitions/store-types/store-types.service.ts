import { Injectable } from '@angular/core';
import {DataService} from '../../../shared/services/data.service';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';
import {IStoreType} from '../../../shared/models/store-type';
import {BaseDataService} from '../../../shared/models/base-data-service';
import {IAddModel} from '../../../shared/models/iadd-model';
import {IUpdateModel} from '../../../shared/models/iupdate-model';

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
  getList(): Observable<IStoreType[]> {
    const url = this.webApiUrl + 'StoreTypes';

    return this.service.get(url).pipe<IStoreType[]>(tap((response: any) => {
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
