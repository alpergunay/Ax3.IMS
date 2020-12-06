import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AccountsComponent} from './accounts.component';
import {AccountComponent} from './account/account.component';


const routes: Routes = [
  {
    path: '',
    component: AccountsComponent,
    children: [
      {
        path: 'account',
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
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountsRoutingModule {}
