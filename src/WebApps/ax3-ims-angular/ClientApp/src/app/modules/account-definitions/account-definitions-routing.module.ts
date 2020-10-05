import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {Routes} from '@angular/router';
import {AccountsComponent} from '../../accounts/accounts.component';
import {AccountComponent} from '../../accounts/account/account.component';

const routes: Routes = [
  {
    path: '',
    component: AccountsComponent,
    children: [
      {
        path: 'account-definitions',
        component: AccountComponent,
      },
      { path: '', redirectTo: 'account', pathMatch: 'full' },
      {
        path: '**',
        component: AccountComponent,
        pathMatch: 'full',
      },
    ],
  },
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class AccountDefinitionsRoutingModule { }
