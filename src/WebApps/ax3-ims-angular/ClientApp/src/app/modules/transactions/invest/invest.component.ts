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
  selectedAccount: any;
  hideControl = true;
  dataModel = <InvestModel>{};
  constructor(private transactionService: TransactionService,
              private notifyService: NotifyService) {
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
    const errorList = this.validateAddModel();
    if (errorList != null && errorList.length === 0) {
      this.transactionService.putInvestmentToolToAccount(this.dataModel).subscribe(result => {
        this.notifyService.success('Kayıt başarılı bir şekilde eklendi');
      });
    } else {
      this.notifyService.error(errorList);
    }
  }
  clearClicked() {
  }
  selectionChanged(data) {
    if(data !== null)
      this.hideControl = data.investmentToolTypeId !== InvestmentToolTypeEnumModel.LocalCurrency;
  }
}
