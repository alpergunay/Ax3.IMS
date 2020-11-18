import {Component} from '@angular/core';
import {BaseModalComponent} from "../../../../shared/base/base-modal.component";
import {NotifyService} from "../../../../shared/base/notify.service";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {StoreBranchModel} from "../../../../shared/models/store/store-branch.model";
import {StoreBranchService} from "../store-branch.service";

@Component({
  selector: 'app-add-store-branch',
  templateUrl: './add-store-branch.component.html',
  styleUrls: ['./add-store-branch.component.scss']
})
export class AddStoreBranchComponent extends BaseModalComponent<StoreBranchModel> {
  constructor(private storeBranchService: StoreBranchService,
              notifyService: NotifyService,
              activeModal: NgbActiveModal) {
    super(storeBranchService, notifyService, activeModal);
  }

  validateAddModel(): string[] {
    const errorList = [];
    if (this.dataModel.name === undefined) {
      errorList.push('Şube Adı Boş Bırakılamaz!');
    }
    if(this.dataModel.storeTypeId === undefined){
      errorList.push('Saklama Yeri Tipi Boş Bırakılamaz!');
    }
    if(this.dataModel.storeId === undefined){
      errorList.push('Saklama Yeri Boş Bırakılamaz!');
    }
    return errorList;
  }

  validateUpdateModel(): string[] {
    const errorList = [];
    if (this.dataModel.name === undefined) {
      errorList.push('Şube Adı Boş Bırakılamaz!');
    }
    if(this.dataModel.storeTypeId === undefined){
      errorList.push('Saklama Yeri Tipi Boş Bırakılamaz!');
    }
    if(this.dataModel.storeId === undefined){
      errorList.push('Saklama Yeri Boş Bırakılamaz!');
    }
    return errorList;
  }
}
