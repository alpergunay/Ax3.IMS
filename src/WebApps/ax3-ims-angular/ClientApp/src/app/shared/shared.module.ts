import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

// Services
import { DataService } from './services/data.service';
import { SecurityService } from './services/security.service';
import { ConfigurationService } from './services/configuration.service';
import { StorageService } from './services/storage.service';
import { SignalrService } from './services/signalr.service';

// Components:
import { Pager } from './components/pager/pager';
import { Header } from './components/header/header';
import { Identity } from './components/identity/identity';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { PageTemplateHeaderComponent } from './components/page-template-header/page-template-header.component';
import { PageTemplateComponent } from './components/page-template/page-template.component';
import {DxButtonModule, DxDataGridModule, DxTextBoxModule} from 'devextreme-angular';
import {DialogComponent} from './base/dialog/dialog.component';
import {InputDialogComponent} from './base/input-dialog/input-dialog.component';
import {ConfirmationComponent} from './base/confirmation/confirmation.component';
import {NotifyService} from './base/notify.service';
import {ToastrModule} from "ngx-toastr";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    NgbModule,
    HttpClientModule,
    HttpClientJsonpModule,
    DxButtonModule,
    DxDataGridModule,
    DxTextBoxModule,
    ToastrModule.forRoot({
      preventDuplicates: true,
    }),
  ],
  declarations: [
    Pager,
    Header,
    Identity,
    PageNotFoundComponent,
    PageTemplateHeaderComponent,
    PageTemplateComponent,
    DialogComponent,
    InputDialogComponent,
    ConfirmationComponent
  ],
  exports: [
    // Modules
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    NgbModule,
    // Providers, Components, directive, pipes
    Pager,
    Header,
    Identity,
    PageNotFoundComponent,
    PageTemplateComponent,
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders<SharedModule> {
    return {
      ngModule: SharedModule,
      providers: [
        // Providers
        DataService,
        SecurityService,
        ConfigurationService,
        StorageService,
        SignalrService,
        NotifyService
      ]
    };
  }
}
