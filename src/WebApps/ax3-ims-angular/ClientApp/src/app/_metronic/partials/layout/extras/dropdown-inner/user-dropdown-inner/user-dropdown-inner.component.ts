import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { LayoutService } from '../../../../../core';
import { UserModel } from '../../../../../../modules/auth/_models/user.model';
import { SecurityService } from "../../../../../../shared/services/security.service";

@Component({
  selector: 'app-user-dropdown-inner',
  templateUrl: './user-dropdown-inner.component.html',
  styleUrls: ['./user-dropdown-inner.component.scss'],
})
export class UserDropdownInnerComponent implements OnInit {
  extrasUserDropdownStyle: 'light' | 'dark' = 'light';
  user$: Observable<UserModel>;
  authenticated = false;
  public userName = '';
  public userSurname = '';


  constructor(private layout: LayoutService, private securityService: SecurityService) {
    this.authenticated = securityService.IsAuthorized;
  }

  ngOnInit(): void {
    this.extrasUserDropdownStyle = this.layout.getProp(
      'extras.user.dropdown.style'
    );
    if (this.authenticated) {
      if (this.securityService.UserData) {
        this.userName = this.securityService.UserData.name;
        this.userSurname = this.securityService.UserData.last_name;
      }
    }
  }

  logout() {
    this.securityService.Logoff();
    document.location.reload();
  }
}
