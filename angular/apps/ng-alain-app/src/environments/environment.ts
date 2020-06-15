export const environment = {
  production: false,
  hmr:false,
  application: {
    name: 'JobsManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44353',
    clientId: 'JobsManagement_ConsoleTestApp',
    dummyClientSecret: '1q2w3e*',
    scope: 'JobsManagement',
    showDebugInformation: true,
    oidc: false,
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44318',
    },
  },
};
