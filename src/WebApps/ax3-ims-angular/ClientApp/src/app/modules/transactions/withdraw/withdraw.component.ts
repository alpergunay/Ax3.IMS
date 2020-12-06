import {Component, Inject, LOCALE_ID, OnInit, ViewChild} from '@angular/core';
import {InvestModel} from "../../../shared/models/transaction/invest.model";
import {TransactionService} from "../transaction.service";
import {NotifyService} from "../../../shared/base/notify.service";
import {TransactionTypeEnumModel} from "../../../shared/models/transaction-type-enum.model";
import {formatDate} from "@angular/common";
import {InvestmentToolTypeEnumModel} from "../../../shared/models/investment-tool-type-enum.model";
import {AccountLookupComponent} from "../../accounts/account/account-lookup/account-lookup.component";

@Component({
  selector: 'app-withdraw',
  templateUrl: './withdraw.component.html',
  styleUrls: ['./withdraw.component.scss']
})
export class WithdrawComponent implements OnInit {
  hideRateControl = false;
  dataModel = <InvestModel>{};
  datePlaceholder = "";
  @ViewChild(AccountLookupComponent, { static: false }) accountLookup: AccountLookupComponent;

  constructor(private transactionService: TransactionService,
              private notifyService: NotifyService,
              @Inject(LOCALE_ID) private locale: string) {
    this.dataModel.transactionTypeId = TransactionTypeEnumModel.Withdraw;
    this.dataModel.rate = 1;
    this.dataModel.transactionDate = new Date();
    this.datePlaceholder = formatDate(Date.now(), 'dd-MM-yyyy', locale);
  }

  ngOnInit(): void {
  }

  validateAddModel(): string[] {
    const errorList = [];
    if (this.dataModel.transactionDate == null) {
      errorList.push('Hareket Tarihi Boş Bırakılamaz!');
    }
    if (this.dataModel.accountId == null) {
      errorList.push('Hesap Boş Bırakılamaz!');
    }
    if (this.dataModel.amount == null) {
      errorList.push('Miktar Boş Bırakılamaz!');
    }
    if (this.hideRateControl == true && this.dataModel.rate == null) {
      errorList.push('Alış Kuru Boş Bırakılamaz!');
    }
    if (this.dataModel.amount > this.dataModel.balance) {
      errorList.push('Hesabınızda çıkartmak istediğiniz miktar kadar yatırım aracı bulunmuyor !');
    }
    return errorList;
  }

  validateUpdateModel(): string[] {
    const errorList = [];
    if (this.dataModel.transactionDate === undefined) {
      errorList.push('Hareket Tarihi Boş Bırakılamaz!');
    }
    if (this.dataModel.accountId === undefined) {
      errorList.push('Hesap Boş Bırakılamaz!');
    }
    if (this.dataModel.amount === undefined) {
      errorList.push('Miktar Boş Bırakılamaz!');
    }
    if (this.hideRateControl == false && this.dataModel.rate === undefined) {
      errorList.push('Alış Kuru Boş Bırakılamaz!');
    }
    return errorList;
  }

  saveClicked() {
    const errorList = this.validateAddModel();
    if (errorList != null && errorList.length === 0) {
      this.transactionService.withdraw(this.dataModel).subscribe(result => {
        if (result == true) {
          this.notifyService.success('Kayıt başarılı bir şekilde eklendi');
          this.accountLookup.reloadLookupData();
          this.clearControls();
        } else {
          errorList.push('Kayıt eklemede bir hata meydana geldi. Lütfen hesapta yeterli miktar olduğundan emin olunuz.')
          this.notifyService.error(errorList);
        }
      });
    } else {
      this.notifyService.error(errorList);
    }
  }

  clearClicked() {
    this.clearControls();
  }

  selectionChanged(data) {
    if (data !== null) {
      this.hideRateControl = data.investmentToolTypeId !== InvestmentToolTypeEnumModel.LocalCurrency;
      this.dataModel.accountId = data.id;
    }
  }

  clearControls() {
    this.dataModel.accountId = <string>{};
    this.dataModel.description = '';
    this.dataModel.accountName = '';
    this.dataModel.amount = 0;
    this.dataModel.transactionDate = new Date();
    this.dataModel.rate = 0;
  }

  numberBoxValueChanged(e) {
    if (e.value === null) {
      e.component.option("value", 1);
    }
  }
}
