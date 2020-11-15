import { Injectable } from '@angular/core';
import {BaseDataService} from "../../../shared/models/base-data-service";
import {BaseModel} from "../../../shared/models/base-add.model";
import {tap} from "rxjs/operators";
import {DataService} from "../../../shared/services/data.service";
import {ConfigurationService} from "../../../shared/services/configuration.service";
import {BaseRequestModel} from "../../../shared/models/base-request.model";
import {StoreBranchModel} from "../../../shared/models/store/store-branch.model";

@Injectable({
  providedIn: 'root'
})
export class StoreBranchService implements BaseDataService{
  private webApiUrl = '';
  constructor(private service: DataService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.webApiUrl = this.configurationService.serverSettings.imsApiClient;
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => this.webApiUrl = this.configurationService.serverSettings.imsApiClient);
    }
  }

  add(addModel: BaseModel) {
    const url = this.webApiUrl + '/api/StoreBranch';
    return this.service.post(url, addModel).pipe<boolean>(tap((response: any) => true));
  }

  delete() {
  }

  dxGetList() {
    const url = this.webApiUrl + '/api/StoreBranch/list';
    return this.service.dxGet(url, <BaseRequestModel>{});
  }

  getById(id: any) {
    const url = this.webApiUrl + '/api/StoreBranch/' + id;
    return this.service.get(url).pipe<StoreBranchModel>(tap((response: any) => {
      return response;
    }));
  }

  getList() {
    const url = this.webApiUrl + '/api/StoreBranch';

    return this.service.get(url).pipe<StoreBranchModel[]>(tap((response: any) => {
      return response;
    }));
  }

  update(updateModel: BaseModel) {
    const url = this.webApiUrl + '/api/StoreBranch';
    return this.service.putWithId(url, updateModel).pipe<boolean>(tap((response: any) => true));
  }

  getLookupList(typed: string) {
  }
}
