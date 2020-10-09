import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AccountTypesComponent} from './account-types/account-types.component';
import {AccountDefinitionsComponent} from './account-definitions.component';

const routes: Routes = [
  {
    path: '',
    component: AccountDefinitionsComponent,
    children: [
      {
        path: 'account-types',
        component: AccountTypesComponent,
      },
      { path: '', redirectTo: 'account-types', pathMatch: 'full' },
      {
        path: '**',
        component: AccountTypesComponent,
        pathMatch: 'full',
      },
    ],
  },
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountDefinitionsRoutingModule { }
