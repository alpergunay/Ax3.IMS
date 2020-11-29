import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AssetComponent} from './asset/asset.component';
import {AssetsComponent} from './assets.component';
import {AssetsRoutingModule} from "./assets-routing.module";
import {DxAccordionModule} from "devextreme-angular";


@NgModule({
  declarations: [AssetComponent, AssetsComponent],
  imports: [
    CommonModule,
    AssetsRoutingModule,
    DxAccordionModule
  ]
})
export class AssetsModule {
}
