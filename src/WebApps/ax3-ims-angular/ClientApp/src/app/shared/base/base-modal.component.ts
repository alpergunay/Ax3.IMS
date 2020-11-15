import {Component, OnInit} from '@angular/core';
import {BaseDataService} from '../models/base-data-service';
import {NotifyService} from './notify.service';
import {NgbActiveModal} from '@ng-bootstrap/ng-bootstrap';
import {ProcessType} from "../models/process-type";

@Component({
  template: ''
})
export abstract class BaseModalComponent<T> implements OnInit {
  protected constructor(private service: BaseDataService,
                        private notifyService: NotifyService,
                        public activeModal: NgbActiveModal) {
  }
  dataModel = <T>{};
  processType: ProcessType;
  abstract validateAddModel(): string[];

  abstract validateUpdateModel(): string[];
  ngOnInit(): void {
  }
  saveClicked() {
    if(this.processType == ProcessType.Add){
      const errorList = this.validateAddModel();
      if (errorList != null && errorList.length === 0) {
        this.addData();
      } else {
        this.notifyService.error(errorList);
      }
    }
    else if(this.processType == ProcessType.Update) {
      const errorList = this.validateUpdateModel();
      if (errorList != null && errorList.length === 0) {
        this.updateData()
      } else {
        this.notifyService.error(errorList);
      }
    }

  }
  addData() {
    this.service.add(this.dataModel).subscribe(result => {
      this.notifyService.success('Kayıt başarılı bir şekilde eklendi');
      this.closeModal();
    });
  }

  updateData() {
    this.service.update(this.dataModel).subscribe(result => {
      this.notifyService.success('Kayıt başarılı bir şekilde güncellendi');
      this.closeModal();
    });
  }
  closeModal() {
    this.activeModal.close();
  }
}
