import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountDefinitionsComponent } from './account-definitions.component';
import {SharedModule} from '../../shared/shared.module';
import {AccountDefinitionsRoutingModule} from './account-definitions-routing.module';
import { AccountTypesComponent } from './account-types/account-types.component';



@NgModule({
  declarations: [AccountDefinitionsComponent, AccountTypesComponent],
  imports: [
    CommonModule,
    AccountDefinitionsRoutingModule,
    SharedModule
  ]
})
export class AccountDefinitionsModule { }
