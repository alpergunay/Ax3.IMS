import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {StoreDefinitionsComponent} from './store-definitions.component';
import {StoreTypesComponent} from './store-types/store-types.component';
import {StoresComponent} from './stores/stores.component';
import {StoreBranchesComponent} from './store-branches/store-branches.component';

const routes: Routes = [
  {
    path: '',
    component: StoreDefinitionsComponent,
    children: [
      {
        path: 'store-types',
        component: StoreTypesComponent,
      },
      {
        path: 'stores',
        component: StoresComponent,
      },
      {
        path: 'store-branches',
        component: StoreBranchesComponent,
      },
      { path: '', redirectTo: 'store-types', pathMatch: 'full' },
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
