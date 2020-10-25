import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-input-dialog',
  templateUrl: './input-dialog.component.html',
})
export class InputDialogComponent implements OnInit {

  @Input() title: string;
  @Input() message: string;
  @Input() btnOkText: string;
  customCssClass: string;
  inputValue: string;

  constructor(private activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  public close() {
    this.activeModal.close(this.inputValue);
  }

  public dismiss() {
    this.activeModal.dismiss();
  }

  onEnterPressedInput(e) {
    this.close();
  }
}
