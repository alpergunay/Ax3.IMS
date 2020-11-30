import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TransactionsComponent } from './transactions.component';
import { InvestComponent } from './invest/invest.component';
import { WithdrawComponent } from './withdraw/withdraw.component';
import { BuyInvestmentToolComponent } from './buy-investment-tool/buy-investment-tool.component';
import { SellInvestmentToolComponent } from './sell-investment-tool/sell-investment-tool.component';
import {TransactionsRoutingModule} from "./transactions-routing.module";
import {AccountsModule} from "../accounts/accounts.module";
import {DxButtonModule, DxNumberBoxModule, DxTextBoxModule} from "devextreme-angular";



@NgModule({
  declarations: [TransactionsComponent, InvestComponent, WithdrawComponent, BuyInvestmentToolComponent, SellInvestmentToolComponent],
  imports: [
    CommonModule,
    TransactionsRoutingModule,
    AccountsModule,
    DxTextBoxModule,
    DxNumberBoxModule,
    DxButtonModule
  ]
})
export class TransactionsModule { }
