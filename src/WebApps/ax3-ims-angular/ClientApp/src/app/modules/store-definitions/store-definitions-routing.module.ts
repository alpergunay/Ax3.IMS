import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {StoreDefinitionsComponent} from './store-definitions.component';
import {StoreTypesComponent} from './store-types/store-types.component';

const routes: Routes = [
  {
    path: '',
    component: StoreDefinitionsComponent,
    children: [
      {
        path: 'investment-tool-types',
        component: StoreTypesComponent,
      },
      { path: '', redirectTo: 'investment-tool-types', pathMatch: 'full' },
      {
        path: '**',
        component: StoreTypesComponent,
        pathMatch: 'full',
      },
    ],
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class StoreDefinitionsRoutingModule { }
