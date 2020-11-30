import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './_layout/layout.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: 'dashboard',
        loadChildren: () =>
          import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
      },
      {
        path: 'assets',
        loadChildren: () =>
          import('../modules/assets/assets.module').then((m) => m.AssetsModule),
      },
      {
        path: 'accounts',
        loadChildren: () =>
          import('../modules/accounts/accounts.module').then((m) => m.AccountsModule),
      },
      {
        path: 'transactions',
        loadChildren: () =>
          import('../modules/transactions/transactions.module').then((m) => m.TransactionsModule),
      },
      {
        path: 'account-definitions',
        loadChildren: () =>
          import('../modules/account-definitions/account-definitions.module').then((m) => m.AccountDefinitionsModule),
      },
      {
        path: 'investment-tool-definitions',
        loadChildren: () =>
          import('../modules/investment-tool-definitions/investment-tool-definitions.module').then((m) =>
            m.InvestmentToolDefinitionsModule),
      },
      {
        path: 'store-definitions',
        loadChildren: () =>
          import('../modules/store-definitions/store-definitions.module').then((m) =>
            m.StoreDefinitionsModule),
      },
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
      },
      {
        path: '**',
        redirectTo: 'errors/404',
        pathMatch: 'full',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
