import {Component, ElementRef, OnInit, Renderer2} from '@angular/core';
import {NotifyService} from './notify.service';
import {NgbModal, NgbModalOptions, NgbModalRef} from '@ng-bootstrap/ng-bootstrap';
import {BaseDataService} from '../models/base-data-service';
import {catchError} from 'rxjs/operators';
import {throwError} from 'rxjs';
import {ConfigurationService} from '../services/configuration.service';
@Component({
  template: ''
})
export abstract class BaseComponent<TCreate, TUpdate> implements OnInit {
  protected constructor(private service: BaseDataService,
                        private notifyService: NotifyService,
                        private modalService: NgbModal,
                        private configurationService: ConfigurationService) {
  }
  addModel = <TCreate>{};
  updateModel = <TUpdate>{};
  dataSource: any;
  loading = false;
  modalRef: NgbModalRef;
  isPopupVisible = false;
  title = '';
  modalOptions: NgbModalOptions;
  renderer: Renderer2;
  elementRef: ElementRef;
  errorReceived: boolean;
  abstract validateAddModel(): string[];
  abstract validateUpdateModel(): string[];
  ngOnInit(): void {
    if (this.configurationService.isReady) {
      this.listData();
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.listData();
      });
    }
  }
  listData() {
    this.errorReceived = false;
    this.service.getList()
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(data => {
        this.dataSource = data;
      });
  }
  private handleError(error: any) {
    this.errorReceived = true;
    return throwError(error);
  }

  addClicked() {
    const errorList = this.validateAddModel();
    if (errorList != null && errorList.length === 0) {
      this.addData();
    } else {
      this.notifyService.error(errorList);
    }
  }
  updateClicked() {
    const errorList = this.validateUpdateModel();
    if (errorList != null && errorList.length === 0) {
      this.updateData();
    } else {
      this.notifyService.error(errorList);
    }
  }

  addData() {
    this.loading = true;
    this.service.add(this.addModel).subscribe(result => {
      this.loading = false;
      if (result.isSuccess) {
        this.processResult(result);
        this.notifyService.success('Kayıt Başarılı!');
      } else {
        this.notifyService.error(result.exceptionMessage);
      }
    });
  }
  updateData() {
    this.loading = true;
    this.service.update(this.updateModel).subscribe(result => {
      this.loading = false;
      if (result.isSuccess) {
        this.processResult(result);
        this.notifyService.success('Kayıt Güncellendi!');
      } else {
        this.notifyService.error(result.exceptionMessage);
      }
    });
  }
  processResult(result: any) {
    if (result.data !== undefined && result.data != null && result.data.isValid !== undefined) {
      if (result.data.isValid !== true) {
        this.notifyService.errorResponseMessage(result.data.responseMessages);
        return;
      }
    }
    if (this.modalRef) {
      this.modalRef.close();
    } else {
      this.isPopupVisible = false;
    }
    this.listData();
  }
  getById(id) {
    return this.service.getById(id);
  }
  openPopup(modalName: string, parameters?: any) {
    const that = this;
    switch (modalName) {
      case 'add':
        this.isPopupVisible = true;
        this.addModel = <TCreate>{};
        that.renderer.selectRootElement (that.elementRef.nativeElement.ownerDocument.activeElement).blur();
        that.addClicked();
        break;
      case 'update':
        if (parameters != null && parameters.SelectedRowId != null && parameters.SelectedRowId > 0) {
          this.updateModel = <TUpdate>{};
          this.getById(parameters.SelectedRowId).subscribe(result => {
            if (result.isSuccess === true) {
              this.updateModel = result.data;
              this.isPopupVisible = true;
              that.renderer.selectRootElement(that.elementRef.nativeElement.ownerDocument.activeElement).blur();
              that.updateClicked();
            } else {
              this.notifyService.error(result.exceptionMessage);
            }
          });
        }
        break;
      default:
        break;
    }
  }
  openModal(content: any, modalName: string, parameters?: any) {
    const that = this;
    const options = this.modalOptions;
    switch (modalName) {
      case 'add':
        this.modalRef = this.modalService.open(content, options);
        this.addModel = <TCreate>{};
        that.renderer.selectRootElement(that.elementRef.nativeElement.ownerDocument.activeElement).blur();
        that.addClicked();
        break;
      case 'update':
        if (parameters != null && parameters.SelectedRowId != null && parameters.SelectedRowId > 0) {
          this.updateModel = <TUpdate>{};
          this.getById(parameters.SelectedRowId).subscribe(result => {
            if (result.isSuccess === true) {
              this.updateModel = result.data;
              this.modalRef = this.modalService.open(content, options);
                that.renderer.selectRootElement(that.elementRef.nativeElement.ownerDocument.activeElement).blur();
                that.updateClicked();
            } else {
              this.notifyService.error(result.exceptionMessage);
            }
          });
        }
        break;
      default:
        break;
    }
  }
}
