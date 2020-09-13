import { NgModule } from '@angular/core';
import { AccountsComponent } from './accounts.component';
import { LayoutModule } from "../layout.module";


@NgModule({
  declarations: [AccountsComponent],
  imports: [
    LayoutModule
  ]
})
export class AccountsModule { }
