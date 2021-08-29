import { Component, OnInit } from '@angular/core';
import { AuthGuard } from 'src/app/core/auth-guard';
import { authConfig } from 'src/app/core/auth-config';
import { JwksValidationHandler, OAuthService } from 'angular-oauth2-oidc';

export class SecureService implements OnInit {

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

  public validateLogin(){
        if(!this.isLogged())
            this.login();
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
