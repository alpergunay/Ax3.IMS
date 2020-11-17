import { Component } from '@angular/core';
import {BaseModalComponent} from "../../../../shared/base/base-modal.component";
import {NotifyService} from "../../../../shared/base/notify.service";
import {NgbActiveModal} from "@ng-bootstrap/ng-bootstrap";
import {InvestmentToolModel} from "../../../../shared/models/investment-tool.model";
import {InvestmentToolsService} from "../investment-tools.service";

@Component({
  selector: 'app-add-investment-tool',
  templateUrl: './add-investment-tool.component.html',
  styleUrls: ['./add-investment-tool.component.scss']
})
export class AddInvestmentToolComponent extends BaseModalComponent<InvestmentToolModel> {

  constructor(private investmentToolService: InvestmentToolsService,
              notifyService: NotifyService,
              activeModal: NgbActiveModal) {
    super(investmentToolService, notifyService, activeModal);
  }

  validateAddModel(): string[] {
    const errorList = [];
    if(this.dataModel.investmentToolTypeId === undefined){
      errorList.push('Yatırım Aracı Tipi Boş Bırakılamaz!');
    }
    if (this.dataModel.code === undefined) {
      errorList.push('Yatırım Aracı Kodu Boş Bırakılamaz!');
    }
    if(this.dataModel.name === undefined){
      errorList.push('Yatırım Aracı Açıklaması Boş Bırakılamaz!');
    }
    return errorList;
  }

  validateUpdateModel(): string[] {
    const errorList = [];
    if(this.dataModel.investmentToolTypeId === undefined){
      errorList.push('Yatırım Aracı Tipi Boş Bırakılamaz!');
    }
    if (this.dataModel.code === undefined) {
      errorList.push('Yatırım Aracı Kodu Boş Bırakılamaz!');
    }
    if(this.dataModel.name === undefined){
      errorList.push('Yatırım Aracı Açıklaması Boş Bırakılamaz!');
    }
    return errorList;
  }
}
