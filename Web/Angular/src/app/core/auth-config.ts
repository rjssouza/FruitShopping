import { AuthConfig } from 'angular-oauth2-oidc';
import { identityServerUrl } from '../config/api';

export const authConfig: AuthConfig = {

    issuer: identityServerUrl,
    clientId: 'angularUI',
    postLogoutRedirectUri: 'http://localhost:4200/',
    redirectUri: window.location.origin,
    scope:"openid profile email FruitApi.full_access",
    oidc: true,
}