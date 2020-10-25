import { Injectable } from '@angular/core';
import {AccountAddModel} from '../../../shared/models/account/account-add-model';
import {AccountUpdateModel} from '../../../shared/models/account/account-update-model';
import {BaseDataService} from '../../../shared/models/base-data-service';

@Injectable({
  providedIn: 'root'
})
export class AccountService implements BaseDataService {

  constructor() { }

  add(addModel: AccountAddModel) {

  }

  delete() {
  }

  getById(id: any) {
  }

  getList() {
  }

  update(updateModel: AccountUpdateModel) {
  }
}
