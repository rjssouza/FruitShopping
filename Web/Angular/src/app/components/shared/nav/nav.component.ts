import { Component, OnInit } from '@angular/core';
import { AuthGuard } from 'src/app/core/auth-guard';
import { authConfig } from 'src/app/core/auth-config';
import { JwksValidationHandler, OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private oauthService: OAuthService) { 
    this.configure();

  }

  private configure() {
    this.oauthService.configure(authConfig);
    this.oauthService.setStorage(localStorage);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    this.oauthService.loadDiscoveryDocumentAndTryLogin();
    this.oauthService.setupAutomaticSilentRefresh();
  }

  ngOnInit() {
  }

  public login() {
    this.oauthService.initLoginFlow();
  }

  public isLogged() {
    return this.oauthService.hasValidAccessToken();
  }

  public logoff() {
    this.oauthService.logOut();
  }

}
