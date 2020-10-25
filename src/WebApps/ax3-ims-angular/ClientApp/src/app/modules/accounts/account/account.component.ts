import {Component, ViewChild} from '@angular/core';
import {DataGridColumnModel} from '../../../shared/components/page-template/data-grid-column-model';
import {PageTemplateComponent} from '../../../shared/components/page-template/page-template.component';
import {BaseComponent} from '../../../shared/base/base.component';
import {AccountService} from './account.service';
import {NotifyService} from '../../../shared/base/notify.service';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss']
})
export class AccountComponent extends BaseComponent<null, null> {
  Columns: DataGridColumnModel[] = [];
  @ViewChild(PageTemplateComponent) pageTemplate: PageTemplateComponent;
  DataSource: any;
  constructor(private accountService: AccountService, notifyService: NotifyService, modalService: NgbModal) {
    super(accountService, notifyService, modalService);
  }

  validateAddModel(): string[] {
    return [];
  }

  validateUpdateModel(): string[] {
    return [];
  }

}
