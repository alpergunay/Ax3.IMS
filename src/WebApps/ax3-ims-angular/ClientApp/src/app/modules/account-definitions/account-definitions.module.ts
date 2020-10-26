import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountDefinitionsComponent } from './account-definitions.component';
import {SharedModule} from '../../shared/shared.module';
import {AccountDefinitionsRoutingModule} from './account-definitions-routing.module';
import { AccountTypesComponent } from './account-types/account-types.component';
import {DxLookupModule} from 'devextreme-angular';
import { AccountTypesLookupComponent } from './account-types/account-types-lookup/account-types-lookup.component';



@NgModule({
  declarations: [AccountDefinitionsComponent, AccountTypesComponent, AccountTypesLookupComponent],
  exports: [
    AccountTypesLookupComponent
  ],
  imports: [
    CommonModule,
    AccountDefinitionsRoutingModule,
    SharedModule,
    DxLookupModule
  ]
})
export class AccountDefinitionsModule { }
