import { Injectable } from '@angular/core';
import {BaseDataService} from "../../shared/models/base-data-service";
import {DataService} from "../../shared/services/data.service";
import {ConfigurationService} from "../../shared/services/configuration.service";
import {StoreBranchModel} from "../../shared/models/store/store-branch.model";
import {Observable} from "rxjs";
import {LookupResponseModel} from "../../shared/models/lookup.model";
import {InvestModel} from "../../shared/models/transaction/invest.model";
import {tap} from "rxjs/operators";
import {BuySellModel} from "../../shared/models/transaction/buy-sell.model";

@Injectable({
  providedIn: 'root'
})
export class TransactionService implements BaseDataService{
  private webApiUrl = '';
  constructor(private service: DataService, private configurationService: ConfigurationService) {
    if (this.configurationService.isReady) {
      this.webApiUrl = this.configurationService.serverSettings.imsApiClient;
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => this.webApiUrl = this.configurationService.serverSettings.imsApiClient);
    }
  }

  add(addModel: InvestModel) {
    return;
  }

  invest(model: InvestModel) :Observable<boolean> {
    const url = this.webApiUrl + '/api/AccountTransaction/invest';
    return this.service.post(url, model).pipe<boolean>(tap((response: any) => true));
  }

  withdraw(model: InvestModel) :Observable<boolean> {
    const url = this.webApiUrl + '/api/AccountTransaction/withdraw';
    return this.service.post(url, model).pipe<boolean>(tap((response: any) => true));
  }

  buyInvestmentTool(model: BuySellModel) :Observable<boolean> {
    const url = this.webApiUrl + '/api/AccountTransaction/buy';
    return this.service.post(url, model).pipe<boolean>(tap((response: any) => true));
  }

  sellInvestmentTool(model: BuySellModel) :Observable<boolean> {
    const url = this.webApiUrl + '/api/AccountTransaction/sell';
    return this.service.post(url, model).pipe<boolean>(tap((response: any) => true));
  }

  delete() {
  }

  dxGetList() {
    return;
  }

  getById(id: any) {
    return;
  }

  getList() {
    return;
  }

  update(updateModel: StoreBranchModel) {
   return;
  }

  getLookupList(typed: string , parentId?: any) : Observable<LookupResponseModel[]> {
    return ;
  }
}
