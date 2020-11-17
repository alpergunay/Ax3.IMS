import { Injectable } from '@angular/core';
import {DataService} from '../../../shared/services/data.service';
import {ConfigurationService} from '../../../shared/services/configuration.service';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';
import {StoreType} from '../../../shared/models/store-type.model';
import {BaseDataService} from '../../../shared/models/base-data-service';
import {BaseModel} from '../../../shared/models/base-add.model';
import {LookupRequestModel, LookupResponseModel} from '../../../shared/models/lookup.model';
import CustomStore from "devextreme/data/custom_store";
import {BaseRequestModel} from "../../../shared/models/base-request.model";

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
    const url = this.webApiUrl + '/api/StoreType';

    return this.service.get(url).pipe<StoreType[]>(tap((response: any) => {
      return response;
    }));
  }

  getLookupList(typed: string, parentId?: any): Observable<LookupResponseModel[]> {
    const url = this.webApiUrl + '/api/StoreType/filter';
    const requestModel = <LookupRequestModel>{};
    requestModel.typed = typed;
    requestModel.id = parentId;
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
    const url = this.webApiUrl + '/api/StoreType/list';
    return this.service.dxGet(url, <BaseRequestModel>{});
  }
}
