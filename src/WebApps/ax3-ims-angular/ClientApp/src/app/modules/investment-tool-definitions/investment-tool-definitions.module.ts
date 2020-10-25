import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvestmentToolDefinitionsComponent } from './investment-tool-definitions.component';
import { InvestmentToolTypesComponent } from './investment-tool-types/investment-tool-types.component';
import {InvestmentToolDefinitionsRoutingModule} from './investment-tool-definitions-routing.module';
import {SharedModule} from '../../shared/shared.module';



@NgModule({
  declarations: [InvestmentToolDefinitionsComponent, InvestmentToolTypesComponent],
  imports: [
    CommonModule,
    InvestmentToolDefinitionsRoutingModule,
    SharedModule
  ]
})
export class InvestmentToolDefinitionsModule { }
