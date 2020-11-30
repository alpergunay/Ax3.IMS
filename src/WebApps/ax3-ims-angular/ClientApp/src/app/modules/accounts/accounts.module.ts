import { NgModule } from '@angular/core';
import { AccountsComponent } from './accounts.component';
import { AccountComponent } from './account/account.component';
import {CommonModule} from '@angular/common';
import {AccountsRoutingModule} from './accounts-routing.module';
import {SharedModule} from '../../shared/shared.module';
import {AddAccountComponent} from './account/add-account/add-account.component';
import {AccountDefinitionsModule} from '../account-definitions/account-definitions.module';
import {DxButtonModule, DxLookupModule, DxTextBoxModule} from 'devextreme-angular';
import {StoreDefinitionsModule} from "../store-definitions/store-definitions.module";
import {InvestmentToolDefinitionsModule} from "../investment-tool-definitions/investment-tool-definitions.module";
import { TransactionComponent } from './transaction/transaction.component';
import {AccountLookupComponent} from "./account/account-lookup/account-lookup.component";



@NgModule({
  declarations: [AccountsComponent, AccountComponent, AddAccountComponent, TransactionComponent, AccountLookupComponent],
  exports: [AccountLookupComponent],
  imports: [
    CommonModule,
    AccountsRoutingModule,
    SharedModule,
    AccountDefinitionsModule,
    DxTextBoxModule,
    StoreDefinitionsModule,
    DxButtonModule,
    InvestmentToolDefinitionsModule,
    DxLookupModule
  ]
})
export class AccountsModule { }
