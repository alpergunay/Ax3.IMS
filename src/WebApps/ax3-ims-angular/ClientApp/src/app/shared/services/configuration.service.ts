import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { IConfiguration } from '../models/configuration.model';
import { StorageService } from './storage.service';

import { Observable, Subject } from 'rxjs';

@Injectable()
export class ConfigurationService {
  serverSettings: IConfiguration;
  // observable that is fired when settings are loaded from server
  private settingsLoadedSource = new Subject();
  settingsLoaded$ = this.settingsLoadedSource.asObservable();
  isReady = false;

  constructor(private http: HttpClient, private storageService: StorageService) { }

  load() {
    const baseURI = document.baseURI.endsWith('/') ? document.baseURI : `${document.baseURI}/`;
    const url = `${baseURI}Home/Configuration`;
    this.http.get(url).subscribe((response) => {
      this.serverSettings = response as IConfiguration;
      this.storageService.store('identityUrl', this.serverSettings.identityUrl);
      this.storageService.store('imsApiClient', this.serverSettings.imsApiClient);
      this.storageService.store('signalrHubUrl', this.serverSettings.signalrHubUrl);
      this.isReady = true;
      this.settingsLoadedSource.next();
    });
  }
}
