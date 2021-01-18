import { Injectable } from '@angular/core';
import {BaseDataService} from "../../shared/models/base-data-service";
import {DataService} from "../../shared/services/data.service";
import {ConfigurationService} from "../../shared/services/configuration.service";
import {Observable} from "rxjs";
import {tap} from "rxjs/operators";
import CustomStore from "devextreme/data/custom_store";
import {LookupResponseModel} from "../../shared/models/lookup.model";
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
    const url = this.webApiUrl + '/api/User/' + id;
    return this.service.get(url).pipe<UserModel>(tap((response: any) => {
      return response;
    }));
  }

  getList(): Observable<UserModel[]> {
   return;
  }

  update(updateModel: UserModel): Observable<boolean> {
    const url = this.webApiUrl + '/api/User';
    return this.service.putWithId(url, updateModel).pipe<boolean>(tap((response: any) => {
      return true;
    }));
  }

  dxGetList(): CustomStore {
    return;
  }

  getLookupList(typed: string, parentId?: any): Observable<LookupResponseModel[]> {
    return;
  }
}
