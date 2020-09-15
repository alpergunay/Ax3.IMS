import { NgModule } from '@angular/core';
import { AccountsComponent } from './accounts.component';
import { AccountComponent } from './account/account.component';
import {CommonModule} from '@angular/common';
import {AccountsRoutingModule} from './accounts-routing.module';
import {SharedModule} from '../../shared/shared.module';


@NgModule({
  declarations: [AccountsComponent, AccountComponent],
    imports: [
        CommonModule,
        AccountsRoutingModule,
        SharedModule
    ]
})
export class AccountsModule { }
