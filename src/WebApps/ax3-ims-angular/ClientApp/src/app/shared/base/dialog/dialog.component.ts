import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
})
export class DialogComponent implements OnInit {

  @Input() title: string;
  @Input() message: string;
  @Input() btnCloseText: string;

  constructor(private activeModal: NgbActiveModal) { }

  ngOnInit() {
  }

  public close() {
    this.activeModal.close(false);
  }

  public dismiss() {
    this.activeModal.dismiss();
  }

}
