import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountDefinitionsComponent } from './account-definitions.component';
import {AccountsRoutingModule} from '../../accounts/accounts-routing.module';
import {SharedModule} from '../../../shared/shared.module';



@NgModule({
  declarations: [AccountDefinitionsComponent],
  imports: [
    CommonModule,
    AccountsRoutingModule,
    SharedModule
  ]
})
export class AccountDefinitionsModule { }
