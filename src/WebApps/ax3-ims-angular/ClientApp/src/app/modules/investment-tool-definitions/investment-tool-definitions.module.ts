import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvestmentToolDefinitionsComponent } from './investment-tool-definitions.component';
import { InvestmentToolTypesComponent } from './investment-tool-types/investment-tool-types.component';
import {InvestmentToolDefinitionsRoutingModule} from './investment-tool-definitions-routing.module';
import {SharedModule} from '../../shared/shared.module';
import { InvestmentToolsComponent } from './investment-tools/investment-tools.component';
import { AddInvestmentToolComponent } from './investment-tools/add-investment-tool/add-investment-tool.component';
import {DxButtonModule, DxLookupModule, DxTextBoxModule} from "devextreme-angular";
import { InvestmentToolTypeLookupComponent } from './investment-tool-types/investment-tool-type-lookup/investment-tool-type-lookup.component';



@NgModule({
  declarations: [InvestmentToolDefinitionsComponent, InvestmentToolTypesComponent, InvestmentToolsComponent, AddInvestmentToolComponent, InvestmentToolTypeLookupComponent],
  imports: [
    CommonModule,
    InvestmentToolDefinitionsRoutingModule,
    SharedModule,
    DxTextBoxModule,
    DxButtonModule,
    DxLookupModule
  ]
})
export class InvestmentToolDefinitionsModule { }
