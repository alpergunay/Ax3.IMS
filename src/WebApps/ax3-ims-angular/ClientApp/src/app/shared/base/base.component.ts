import {Component, OnInit, ViewChild} from '@angular/core';
import {NotifyService} from './notify.service';
import {NgbModal, NgbModalOptions, NgbModalRef} from '@ng-bootstrap/ng-bootstrap';
import {BaseDataService} from '../models/base-data-service';
import {throwError} from 'rxjs';
import {ConfigurationService} from '../services/configuration.service';
import {PageTemplateComponent} from "../components/page-template/page-template.component";
import {ProcessType} from "../models/process-type";


@Component({
  template: ''
})
export abstract class BaseComponent implements OnInit {
  @ViewChild(PageTemplateComponent) pageTemplate: PageTemplateComponent;
  protected constructor(private service: BaseDataService,
                        private notifyService: NotifyService,
                        private modalService: NgbModal,
                        private configurationService: ConfigurationService) {
    this.modalOptions = {
      backdrop: 'static',
    };
  }

  dataSource: any;
  modalRef: NgbModalRef;
  isPopupVisible = false;
  title = '';
  modalOptions: NgbModalOptions;

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
    this.dataSource = this.service.dxGetList();
  }

  private handleError(error: any) {
    return throwError(error);
  }
  getById(id) {
    return this.service.getById(id);
  }

  openPopup(modalName: string, parameters?: any) {
    switch (modalName) {
      case 'add':
        this.isPopupVisible = true;
        break;
      case 'update':
        if (parameters != null && parameters.SelectedRowId != null && parameters.SelectedRowId > 0) {
          this.getById(parameters.SelectedRowId).subscribe(result => {
            if (result.isSuccess === true) {
              this.isPopupVisible = true;
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

  refreshGrid(){
    this.pageTemplate.DataGrid.instance.getDataSource().reload();
  }

  openModal(content: any, modalName: string, parameters?: any) {
    const options = this.modalOptions;
    switch (modalName) {
      case 'add':
        this.modalRef = this.modalService.open(content, options);
        this.modalRef.componentInstance.processType = ProcessType.Add;
        this.modalRef.result.then((result) => {
          this.refreshGrid();
        });
        break;
      case 'update':
        if (parameters !== undefined && parameters.SelectedRowId !== undefined) {
          this.getById(parameters.SelectedRowId).subscribe(result => {
            if (result !== undefined) {
              this.modalRef = this.modalService.open(content, options);
              this.modalRef.componentInstance.dataModel = result;
              this.modalRef.componentInstance.processType = ProcessType.Update;
              this.modalRef.result.then((result) => {
                this.refreshGrid();
              });
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
  onInitialized(e) {
    setTimeout(() => {
      e.component.focus();
    });
  }
}
