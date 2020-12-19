import {ChangeDetectorRef, Component, Inject, LOCALE_ID, OnInit, ViewChild} from '@angular/core';
import {BuySellModel} from "../../../shared/models/transaction/buy-sell.model";
import {AccountLookupComponent} from "../../accounts/account/account-lookup/account-lookup.component";
import {TransactionService} from "../transaction.service";
import {NotifyService} from "../../../shared/base/notify.service";
import {formatDate} from "@angular/common";
import {InvestmentToolTypeEnumModel} from "../../../shared/models/investment-tool-type-enum.model";
import {AccountService} from "../../accounts/account/account.service";

@Component({
  selector: 'app-sell-investment-tool',
  templateUrl: './sell-investment-tool.component.html',
  styleUrls: ['./sell-investment-tool.component.scss']
})
export class SellInvestmentToolComponent implements OnInit {
  dataModel = <BuySellModel>{};
  datePlaceholder = "";
  hideRateControl = true;
  sourceInvestmentToolId = <string>{};
  @ViewChild(AccountLookupComponent, {static: false}) accountLookup: AccountLookupComponent;

  constructor(private transactionService: TransactionService,
              private accountService: AccountService,
              private notifyService: NotifyService,
              @Inject(LOCALE_ID) private locale: string,
              private ref: ChangeDetectorRef) {
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
    if (this.dataModel.sourceAccountId == null) {
      errorList.push('Hesap Boş Bırakılamaz!');
    }
    if (this.dataModel.destinationAccountId == null) {
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
    if(this.dataModel.sourceAccountId === this.dataModel.destinationAccountId)
      errorList.push('Kaynak ve hedef hesap aynı olamaz !');
    return errorList;
  }

  validateUpdateModel(): string[] {
    const errorList = [];
    if (this.dataModel.transactionDate === undefined) {
      errorList.push('Hareket Tarihi Boş Bırakılamaz!');
    }
    if (this.dataModel.sourceAccountId === undefined) {
      errorList.push('Hesap Boş Bırakılamaz!');
    }
    if (this.dataModel.destinationAccountId == null) {
      errorList.push('Hesap Boş Bırakılamaz!');
    }
    if (this.dataModel.amount === undefined) {
      errorList.push('Miktar Boş Bırakılamaz!');
    }
    if (this.hideRateControl == true && this.dataModel.rate == null) {
      errorList.push('Alış Kuru Boş Bırakılamaz!');
    }
    return errorList;
  }

  saveClicked() {
    const errorList = this.validateAddModel();
    if (errorList != null && errorList.length === 0) {
      this.transactionService.sellInvestmentTool(this.dataModel).subscribe(result => {
        if (result == true) {
          this.notifyService.success('Kayıt başarılı bir şekilde eklendi');
          // refreshing UI
          this.accountLookup.reloadLookupData();
          this.clearControls();
          this.ref.detectChanges();
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

  sourceAccountSelectionChanged(data) {
    if (data !== null) {
      this.dataModel.sourceAccountId = data.id;
      this.accountService.getById(data.id).subscribe(result => {
        if (result != null) {
          this.dataModel.investmentToolTypeName = result.investmentToolTypeName;
          this.dataModel.investmentToolName = result.investmentToolName;
          this.ref.detectChanges();
        }
      });
    }
  }

  destinationAccountSelectionChanged(data) {
    if (data !== null) {
      this.dataModel.destinationAccountId = data.id;
      this.hideRateControl = data.investmentToolTypeId !== InvestmentToolTypeEnumModel.LocalCurrency;
    }
  }

  investmentToolChanged(data)
  {
    this.accountLookup.reloadLookupData();
  }

  clearControls() {
    this.dataModel.sourceAccountId = <string>{};
    this.dataModel.destinationAccountId = <string>{};
    this.dataModel.description = '';
    this.dataModel.sourceAccountName = '';
    this.dataModel.destinationAccountName = '';
    this.dataModel.investmentToolName = '';
    this.dataModel.balance = 0;
    this.dataModel.investmentToolTypeId = 0;
    this.dataModel.investmentToolTypeName = '';
    this.dataModel.amount = 0;
    this.dataModel.transactionDate = new Date();
    this.dataModel.rate = 1;
    this.hideRateControl = false;
  }

  numberBoxValueChanged(e) {
    if (e.value === null) {
      e.component.option("value", 1);
    }
  }
}
