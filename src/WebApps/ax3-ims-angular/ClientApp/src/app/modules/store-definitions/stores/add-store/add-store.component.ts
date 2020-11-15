import {Component} from '@angular/core';
import {NotifyService} from '../../../../shared/base/notify.service';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {StoreService} from '../store.service';
import {BaseModalComponent} from '../../../../shared/base/base-modal.component';
import {StoreModel} from "../../../../shared/models/store/store.model";

@Component({
  selector: 'app-add-store',
  templateUrl: './add-store.component.html',
  styleUrls: ['./add-store.component.scss']
})
export class AddStoreComponent extends BaseModalComponent<StoreModel> {

  constructor(private storeService: StoreService,
              notifyService: NotifyService,
              activeModal: NgbActiveModal) {
    super(storeService, notifyService, activeModal);
  }

  validateAddModel(): string[] {
    const errorList = [];
    if (this.dataModel.name === undefined) {
      errorList.push('Saklama Yeri Adı Boş Bırakılamaz!');
    }
    if(this.dataModel.storeTypeId === undefined){
      errorList.push('Saklama Yeri Tipi Boş Bırakılamaz!');
    }
    return errorList;
  }

  validateUpdateModel(): string[] {
    const errorList = [];
    if (this.dataModel.name === undefined) {
      errorList.push('Saklama Yeri Adı Boş Bırakılamaz!');
    }
    if(this.dataModel.storeTypeId === undefined){
      errorList.push('Saklama Yeri Tipi Boş Bırakılamaz!');
    }
    return errorList;
  }

}
