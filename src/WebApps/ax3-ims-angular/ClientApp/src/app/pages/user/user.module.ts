import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user.component';
import {RouterModule} from "@angular/router";
import {AccountsModule} from "../../modules/accounts/accounts.module";
import {DxButtonModule} from "devextreme-angular";


@NgModule({
  declarations: [UserComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: '',
        component: UserComponent,
      }
    ]),
    AccountsModule,
    DxButtonModule
  ]
})
export class UserModule { }
