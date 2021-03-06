import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';


@Injectable()
export class AuthGuard implements CanActivate {
  constructor(
    private authService: OAuthService,
    private router: Router
  ) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot,
  ): boolean {
        if( this.authService.hasValidAccessToken()){
          return true;
        }

        this.router.navigate(['']);
        return false;
  }
}