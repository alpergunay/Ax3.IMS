import {Component, Input, OnInit} from '@angular/core';
import {BaseLookupComponent} from "../../../../shared/base/base-lookup.component";
import {InvestmentToolsService} from "../investment-tools.service";

@Component({
  selector: 'app-investment-tool-lookup',
  templateUrl: './investment-tool-lookup.component.html',
  styleUrls: ['./investment-tool-lookup.component.scss']
})
export class InvestmentToolLookupComponent extends BaseLookupComponent<string> {
  @Input() selectedInvestmentToolTypeId: number = 0;
  oldInvestmentToolTypeId: number = 0;

  constructor(service: InvestmentToolsService) {
    super (service)
  }

  ngOnChanges(): void {
    if (this.oldInvestmentToolTypeId !== undefined && this.oldInvestmentToolTypeId !== 0  && this.oldInvestmentToolTypeId !== this.selectedInvestmentToolTypeId) {
      setTimeout(() => {
        this.selectedValue = "";
        this.selectedText = "";
      }, 0);
      this.onChange();
    }
    if (this.oldInvestmentToolTypeId !== this.selectedInvestmentToolTypeId) {
      this.parentId = this.selectedInvestmentToolTypeId;
      this.loadData();
    }
    this.oldInvestmentToolTypeId = this.selectedInvestmentToolTypeId;
  }
}
