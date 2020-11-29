import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AssetComponent} from "./asset/asset.component";
import {AssetsComponent} from "./assets.component";


const routes: Routes = [
  {
    path: '',
    component: AssetComponent,
    // children: [
    //   {
    //     path: '',
    //     component: AssetComponent,
    //   },
    //   { path: '', redirectTo: 'asset', pathMatch: 'full' },
    //   {
    //     path: '**',
    //     component: AssetComponent,
    //     pathMatch: 'full',
    //   },
    // ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AssetsRoutingModule {}
