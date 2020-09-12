import { Injectable } from '@angular/core';
import {
  Router,
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';
import { AuthService } from './auth.service';
import { SecurityService } from "../../../shared/services/security.service";

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(private securityService: SecurityService) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const isAuthorized = this.securityService.IsAuthorized;
    if (isAuthorized) {
      // logged in so return true
      return true;
    }

    // not logged in so redirect to login page with the return url
    //this.securityService.Logoff();
    return false;
  }
}
