import { NgModule } from '@angular/core';
import { AccountsComponent } from './accounts.component';
import { AccountComponent } from './account/account.component';
import {CommonModule} from '@angular/common';
import {AccountsRoutingModule} from './accounts-routing.module';


@NgModule({
  declarations: [AccountsComponent, AccountComponent],
  imports: [
    CommonModule,
    AccountsRoutingModule
  ]
})
export class AccountsModule { }
