import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {

    issuer: 'https://localhost:5001',
    clientId: 'angularUI',
    postLogoutRedirectUri: 'http://localhost:4200/',
    redirectUri: window.location.origin,
    scope:"openid profile email",
    oidc: true,
}