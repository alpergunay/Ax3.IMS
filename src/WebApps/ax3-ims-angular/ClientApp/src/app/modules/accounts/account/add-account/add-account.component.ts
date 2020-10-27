import { Component, OnInit } from '@angular/core';
import {BaseComponent} from '../../../../shared/base/base.component';
import {AccountAddModel} from '../../../../shared/models/account/account-add.model';
import {AccountUpdateModel} from '../../../../shared/models/account/account-update.model';
import {AccountService} from '../account.service';
import {NotifyService} from '../../../../shared/base/notify.service';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {ConfigurationService} from '../../../../shared/services/configuration.service';

@Component({
  selector: 'app-add-account',
  templateUrl: './add-account.component.html',
  styleUrls: ['./add-account.component.scss']
})
export class AddAccountComponent extends BaseComponent<AccountAddModel, AccountUpdateModel> implements OnInit {

  constructor(private accountService: AccountService,
              notifyService: NotifyService,
              modalService: NgbModal,
              configurationService: ConfigurationService) {
    super(accountService, notifyService, modalService, configurationService);
  }
  ngOnInit() {
  }

  validateAddModel(): string[] {
    return [];
  }

  validateUpdateModel(): string[] {
    return [];
  }

}
