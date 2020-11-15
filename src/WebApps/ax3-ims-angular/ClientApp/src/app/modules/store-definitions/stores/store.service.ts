import { Injectable } from '@angular/core';
import {BaseDataService} from '../../../shared/models/base-data-service';
import {DataService} from '../../../shared/services/data.service';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';
import CustomStore from 'devextreme/data/custom_store';
import {BaseRequestModel} from "../../../shared/models/base-request.model";
import {LookupRequestModel, LookupResponseModel, LookupResponseModelGuid} from "../../../shared/models/lookup.model";
import {StoreModel} from "../../../shared/models/store/store.model";

@Injectable({
  providedIn: 'root'
})
export class StoreService implements BaseDataService {
  private webApiUrl = '';
  constructor(private service: DataService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.webApiUrl = this.configurationService.serverSettings.imsApiClient;
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => this.webApiUrl = this.configurationService.serverSettings.imsApiClient);
    }
  }

  add(addModel: StoreModel): Observable<boolean> {
    const url = this.webApiUrl + '/api/Store';
    return this.service.post(url, addModel).pipe<boolean>(tap((response: any) => true));
  }

  delete() {
  }

  getById(id: any) {
    const url = this.webApiUrl + '/api/Store/' + id;
    return this.service.get(url).pipe<StoreModel>(tap((response: any) => {
      return response;
    }));
  }

  getList(): Observable<StoreModel[]> {
    const url = this.webApiUrl + '/api/Store';
    return this.service.get(url).pipe<StoreModel[]>(tap((response: any) => {
      return response;
    }));
  }

  update(updateModel: StoreModel) {
    const url = this.webApiUrl + '/api/Store';
    return this.service.putWithId(url, updateModel).pipe<boolean>(tap((response: any) => true));
  }

  dxGetList(): CustomStore {
    const url = this.webApiUrl + '/api/Store/list';
    return this.service.dxGet(url, <BaseRequestModel>{});
  }

  getLookupList(typed: string, parentId?: any): Observable<LookupResponseModel[]> {
    const url = this.webApiUrl + '/api/Store/filter';
    const requestModel = <LookupRequestModel>{};
    requestModel.typed = typed;
    requestModel.id = parentId;
    return this.service.get(url, requestModel).pipe<LookupResponseModel[]>(tap((response: any) => {
      return response;
    }));
  }
}
