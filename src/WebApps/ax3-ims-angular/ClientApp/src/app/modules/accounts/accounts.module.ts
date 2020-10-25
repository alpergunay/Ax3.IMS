import { NgModule } from '@angular/core';
import { AccountsComponent } from './accounts.component';
import { AccountComponent } from './account/account.component';
import {CommonModule} from '@angular/common';
import {AccountsRoutingModule} from './accounts-routing.module';
import {SharedModule} from '../../shared/shared.module';
import {AddAccountComponent} from './account/add-account/add-account.component';


@NgModule({
  declarations: [AccountsComponent, AccountComponent, AddAccountComponent],
    imports: [
        CommonModule,
        AccountsRoutingModule,
        SharedModule
    ]
})
export class AccountsModule { }
