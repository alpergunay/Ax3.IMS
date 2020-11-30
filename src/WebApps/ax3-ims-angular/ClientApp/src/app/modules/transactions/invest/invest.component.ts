import {Component, OnInit} from '@angular/core';
import {NotifyService} from "../../../shared/base/notify.service";
import {InvestModel} from "../../../shared/models/transaction/invest.model";
import {TransactionService} from "../transaction.service";

@Component({
  selector: 'app-invest',
  templateUrl: './invest.component.html',
  styleUrls: ['./invest.component.scss']
})
export class InvestComponent implements OnInit{
  dataModel= <InvestModel>{};

  constructor(transactionService: TransactionService,
              notifyService: NotifyService) {
  }

  ngOnInit(): void {
  }

  validateAddModel(): string[] {
    const errorList = [];
    return errorList;
  }

  validateUpdateModel(): string[] {
    const errorList = [];
    return errorList;
  }
  saveClicked() {
  }
  clearClicked() {
  }
}
