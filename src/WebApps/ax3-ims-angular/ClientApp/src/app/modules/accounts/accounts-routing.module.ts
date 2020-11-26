import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AccountsComponent} from './accounts.component';
import {AccountComponent} from './account/account.component';
import {TransactionComponent} from "./transaction/transaction.component";


const routes: Routes = [
  {
    path: '',
    component: AccountsComponent,
    children: [
      {
        path: 'account',
        component: AccountComponent,
      },
      {
        path: 'transaction',
        component: TransactionComponent,
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
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountsRoutingModule {}
