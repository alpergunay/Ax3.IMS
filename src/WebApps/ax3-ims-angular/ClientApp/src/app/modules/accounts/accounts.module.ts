import { NgModule } from '@angular/core';
import { AccountsComponent } from './accounts.component';
import { AccountComponent } from './account/account.component';
import {CommonModule} from '@angular/common';
import {AccountsRoutingModule} from './accounts-routing.module';
import {SharedModule} from '../../shared/shared.module';
import {AddAccountComponent} from './account/add-account/add-account.component';
import {AccountDefinitionsModule} from '../account-definitions/account-definitions.module';
import {DxButtonModule, DxTextBoxModule} from 'devextreme-angular';
import {StoreDefinitionsModule} from "../store-definitions/store-definitions.module";
import {InvestmentToolDefinitionsModule} from "../investment-tool-definitions/investment-tool-definitions.module";


@NgModule({
  declarations: [AccountsComponent, AccountComponent, AddAccountComponent],
  imports: [
    CommonModule,
    AccountsRoutingModule,
    SharedModule,
    AccountDefinitionsModule,
    DxTextBoxModule,
    StoreDefinitionsModule,
    DxButtonModule,
    InvestmentToolDefinitionsModule
  ]
})
export class AccountsModule { }
