import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {TransactionsComponent} from "./transactions.component";
import {InvestComponent} from "./invest/invest.component";
import {WithdrawComponent} from "./withdraw/withdraw.component";
import {BuyInvestmentToolComponent} from "./buy-investment-tool/buy-investment-tool.component";
import {SellInvestmentToolComponent} from "./sell-investment-tool/sell-investment-tool.component";

const routes: Routes = [
  {
    path: '',
    component: TransactionsComponent,
    children: [
      {
        path: 'invest',
        component: InvestComponent,
      },
      {
        path: 'withdraw',
        component: WithdrawComponent,
      },
      {
        path: 'buy-investment-tool',
        component: BuyInvestmentToolComponent,
      },
      {
        path: 'sell-investment-tool',
        component: SellInvestmentToolComponent,
      },
      { path: '', redirectTo: 'transactions', pathMatch: 'full' },
      {
        path: '**',
        component: TransactionsComponent,
        pathMatch: 'full',
      },
    ],
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TransactionsRoutingModule { }
