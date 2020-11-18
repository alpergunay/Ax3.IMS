import {Component} from '@angular/core';
import {AccountService} from '../account.service';
import {NotifyService} from '../../../../shared/base/notify.service';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {BaseModalComponent} from "../../../../shared/base/base-modal.component";
import {AccountModel} from "../../../../shared/models/account/account.model";

@Component({
  selector: 'app-add-account',
  templateUrl: './add-account.component.html',
  styleUrls: ['./add-account.component.scss']
})
export class AddAccountComponent extends BaseModalComponent<AccountModel> {
  constructor(private accountService: AccountService,
              notifyService: NotifyService,
              activeModal: NgbActiveModal) {
    super(accountService, notifyService, activeModal);
  }

  validateAddModel(): string[] {
    const errorList = [];
    if (this.dataModel.storeBranchId === undefined) {
      errorList.push('Şube Boş Bırakılamaz!');
    }
    if(this.dataModel.storeId === undefined){
      errorList.push('Saklama Yeri Boş Bırakılamaz!');
    }
    if(this.dataModel.accountTypeId === undefined){
      errorList.push('Hesap Tipi Boş Bırakılamaz!');
    }
    if(this.dataModel.investmentToolId === undefined){
      errorList.push('Yatırım Aracı Boş Bırakılamaz!');
    }
    if(this.dataModel.accountName === undefined){
      errorList.push('Hesap Adı Boş Bırakılamaz!');
    }
    return errorList;
  }

  validateUpdateModel(): string[] {
    const errorList = [];
    if (this.dataModel.storeBranchId === undefined) {
      errorList.push('Şube Boş Bırakılamaz!');
    }
    if(this.dataModel.storeId === undefined){
      errorList.push('Saklama Yeri Boş Bırakılamaz!');
    }
    if(this.dataModel.accountTypeId === undefined){
      errorList.push('Hesap Tipi Boş Bırakılamaz!');
    }
    if(this.dataModel.investmentToolId === undefined){
      errorList.push('Yatırım Aracı Boş Bırakılamaz!');
    }
    if(this.dataModel.accountName === undefined){
      errorList.push('Hesap Adı Boş Bırakılamaz!');
    }
    return errorList;
  }
}
