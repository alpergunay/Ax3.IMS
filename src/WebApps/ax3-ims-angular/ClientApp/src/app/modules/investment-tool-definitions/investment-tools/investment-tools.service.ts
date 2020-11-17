import {Injectable} from '@angular/core';
import {BaseDataService} from "../../../shared/models/base-data-service";
import {DataService} from "../../../shared/services/data.service";
import {ConfigurationService} from "../../../shared/services/configuration.service";
import {Observable} from "rxjs";
import {tap} from "rxjs/operators";
import CustomStore from "devextreme/data/custom_store";
import {BaseRequestModel} from "../../../shared/models/base-request.model";
import {LookupRequestModel, LookupResponseModel} from "../../../shared/models/lookup.model";
import {InvestmentToolModel} from "../../../shared/models/investment-tool.model";

@Injectable({
  providedIn: 'root'
})
export class InvestmentToolsService implements BaseDataService {
  private webApiUrl = '';

  constructor(private service: DataService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.webApiUrl = this.configurationService.serverSettings.imsApiClient;
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => this.webApiUrl = this.configurationService.serverSettings.imsApiClient);
    }
  }

  add(addModel: InvestmentToolModel): Observable<boolean> {
    const url = this.webApiUrl + '/api/InvestmentTool';
    return this.service.post(url, addModel).pipe<boolean>(tap((response: any) => true));
  }

  delete() {
  }

  getById(id: any) {
    const url = this.webApiUrl + '/api/InvestmentTool/' + id;
    return this.service.get(url).pipe<InvestmentToolModel>(tap((response: any) => {
      return response;
    }));
  }

  getList(): Observable<InvestmentToolModel[]> {
    const url = this.webApiUrl + '/api/InvestmentTool';
    return this.service.get(url).pipe<InvestmentToolModel[]>(tap((response: any) => {
      return response;
    }));
  }

  update(updateModel: InvestmentToolModel) {
    const url = this.webApiUrl + '/api/InvestmentTool';
    return this.service.putWithId(url, updateModel).pipe<boolean>(tap((response: any) => true));
  }

  dxGetList(): CustomStore {
    const url = this.webApiUrl + '/api/InvestmentTool/list';
    return this.service.dxGet(url, <BaseRequestModel>{});
  }

  getLookupList(typed: string, parentId?: any): Observable<LookupResponseModel[]> {
    const url = this.webApiUrl + '/api/InvestmentTool/filter';
    const requestModel = <LookupRequestModel>{};
    requestModel.typed = typed;
    requestModel.id = parentId;
    return this.service.get(url, requestModel).pipe<LookupResponseModel[]>(tap((response: any) => {
      return response;
    }));
  }
}
