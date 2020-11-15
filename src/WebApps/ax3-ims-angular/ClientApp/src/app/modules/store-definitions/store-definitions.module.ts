import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreDefinitionsComponent } from './store-definitions.component';
import { StoreTypesComponent } from './store-types/store-types.component';
import {StoreDefinitionsRoutingModule} from './store-definitions-routing.module';
import {SharedModule} from '../../shared/shared.module';
import { StoresComponent } from './stores/stores.component';
import { StoreBranchesComponent } from './store-branches/store-branches.component';
import { StoreLookupComponent } from './stores/store-lookup/store-lookup.component';
import { AddStoreComponent } from './stores/add-store/add-store.component';
import {DxButtonModule, DxLookupModule, DxTextBoxModule} from 'devextreme-angular';
import { StoreTypeLookupComponent } from './store-types/store-type-lookup/store-type-lookup.component';
import { AddStoreBranchComponent } from './store-branches/add-store-branch/add-store-branch.component';

@NgModule({
  declarations: [StoreDefinitionsComponent,
    StoreTypesComponent,
    StoresComponent,
    StoreBranchesComponent,
    StoreLookupComponent,
    AddStoreComponent,
    StoreTypeLookupComponent,
    AddStoreBranchComponent],
    imports: [
        CommonModule,
        StoreDefinitionsRoutingModule,
        SharedModule,
        DxTextBoxModule,
        DxLookupModule,
        DxButtonModule
    ]
})
export class StoreDefinitionsModule { }
