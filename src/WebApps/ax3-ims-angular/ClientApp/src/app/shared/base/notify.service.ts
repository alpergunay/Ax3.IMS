import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {ConfirmationComponent} from './confirmation/confirmation.component';
import {DialogComponent} from './dialog/dialog.component';
import {InputDialogComponent} from './input-dialog/input-dialog.component';
import {ResponseMessageModel} from '../models/response-message.model';

@Injectable()
export class NotifyService {

  private toastrOptions = {
    timeOut: 5000,
    enableHtml: true,
    positionClass: 'toast-bottom-center'
  };

  constructor(private toastr: ToastrService, private modalService: NgbModal) {
  }

  /** Yeni satır için mesaj içine <br> tagı eklemek yeterlidir. */
  public confirmationDialog(
    message: string,
    title: string = 'Uyarı',
    btnOkText: string = 'Tamam',
    btnCancelText: string = 'İptal',
    dialogSize: 'sm' | 'lg' = 'sm'): Promise<boolean> {
    const modalRef = this.modalService.open(ConfirmationComponent, { size: dialogSize, centered: true, container: '.confirmation-modal-container' });
    modalRef.componentInstance.title = title;
    modalRef.componentInstance.message = message;
    modalRef.componentInstance.btnOkText = btnOkText;
    modalRef.componentInstance.btnCancelText = btnCancelText;
    return modalRef.result;
  }

  /** Yeni satır için mesaj içine <br> tagı eklemek yeterlidir. */
  public dialogBox(
    message: string,
    title: string = 'Uyarı',
    btnCloseText: string = 'Kapat',
    dialogSize: 'sm' | 'lg' = 'sm'): Promise<boolean> {
    const modalRef = this.modalService.open(DialogComponent, { size: dialogSize, container: '.confirmation-modal-container' , windowClass: 'm-sl-dialog' });
    modalRef.componentInstance.title = title;
    modalRef.componentInstance.message = message;
    modalRef.componentInstance.btnCloseText = btnCloseText;
    return modalRef.result;
  }

  /** Yeni satır için mesaj içine <br> tagı eklemek yeterlidir. */
  public inputDialogBox(
    message: string,
    title: string = 'Veri Giriniz',
    btnOkText: string = 'Tamam',
    dialogSize: 'sm' | 'lg' = 'sm',
    customeCssClass: string = 'ngbModalCustomClass'): Promise<string> {
    const modalRef = this.modalService.open(InputDialogComponent, { size: dialogSize });
    modalRef.componentInstance.title = title;
    modalRef.componentInstance.message = message;
    modalRef.componentInstance.btnOkText = btnOkText;
    modalRef.componentInstance.customCssClass = customeCssClass;
    return modalRef.result;
  }

  public success(message?: string, title?: string) {
    this.toastr.success(message, title, this.toastrOptions);
  }

  public error(message: string[], title?: string) {
    const inMessage = message.join('<br />');
    this.toastr.error(inMessage, title, this.toastrOptions);
  }

  public errorResponseMessage(responseMessages: ResponseMessageModel[], title?: string) {
    const messages: string[] = responseMessages.map(x => x.result);
    const inMessage = messages.join('<br />');
    this.toastr.error(inMessage, title, this.toastrOptions);
  }

  public alert(message?: string, title?: string) {
    this.toastr.warning(message, title, this.toastrOptions);
  }

  public info(message?: string, title?: string) {
    this.toastr.info(message, title, this.toastrOptions);
  }

  public infoResponseMessage(responseMessages: ResponseMessageModel[], title?: string) {
    const messages: string[] = responseMessages.map(x => x.result);
    const inMessage = messages.join('<br />');
    this.toastr.success(inMessage, title, this.toastrOptions);
  }

}
