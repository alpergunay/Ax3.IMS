import { Injectable } from '@angular/core';
import {BaseDataService} from "../../shared/models/base-data-service";
import {DataService} from "../../shared/services/data.service";
import {ConfigurationService} from "../../shared/services/configuration.service";
import {StoreModel} from "../../shared/models/store/store.model";
import {Observable} from "rxjs";
import {tap} from "rxjs/operators";
import CustomStore from "devextreme/data/custom_store";
import {BaseRequestModel} from "../../shared/models/base-request.model";
import {LookupRequestModel, LookupResponseModel} from "../../shared/models/lookup.model";
import {UserModel} from "../../shared/models/user.model";

@Injectable({
  providedIn: 'root'
})
export class UserService implements BaseDataService {
  private webApiUrl = '';
  constructor(private service: DataService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.webApiUrl = this.configurationService.serverSettings.imsApiClient;
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => this.webApiUrl = this.configurationService.serverSettings.imsApiClient);
    }
  }

  add(addModel: UserModel): Observable<boolean> {
    return;
  }

  delete() {
  }

  getById(id: any) {

  }

  getList(): Observable<UserModel[]> {
   return;
  }

  update(updateModel: UserModel): Observable<boolean> {
    const url = this.webApiUrl + '/api/Store';
    return this.service.putWithId(url, updateModel).pipe<boolean>(tap((response: any) => true));
  }

  dxGetList(): CustomStore {
    return;
  }

  getLookupList(typed: string, parentId?: any): Observable<LookupResponseModel[]> {
    return;
  }
}
