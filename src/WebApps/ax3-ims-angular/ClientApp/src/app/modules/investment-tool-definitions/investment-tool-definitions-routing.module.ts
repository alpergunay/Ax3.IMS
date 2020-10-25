import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {InvestmentToolDefinitionsComponent} from './investment-tool-definitions.component';
import {InvestmentToolTypesComponent} from './investment-tool-types/investment-tool-types.component';

const routes: Routes = [
  {
    path: '',
    component: InvestmentToolDefinitionsComponent,
    children: [
      {
        path: 'investment-tool-types',
        component: InvestmentToolTypesComponent,
      },
      { path: '', redirectTo: 'investment-tool-types', pathMatch: 'full' },
      {
        path: '**',
        component: InvestmentToolTypesComponent,
        pathMatch: 'full',
      },
    ],
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InvestmentToolDefinitionsRoutingModule { }
