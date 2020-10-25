import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreDefinitionsComponent } from './store-definitions.component';
import { StoreTypesComponent } from './store-types/store-types.component';
import {StoreDefinitionsRoutingModule} from './store-definitions-routing.module';
import {SharedModule} from '../../shared/shared.module';



@NgModule({
  declarations: [StoreDefinitionsComponent, StoreTypesComponent],
  imports: [
    CommonModule,
    StoreDefinitionsRoutingModule,
    SharedModule
  ]
})
export class StoreDefinitionsModule { }
