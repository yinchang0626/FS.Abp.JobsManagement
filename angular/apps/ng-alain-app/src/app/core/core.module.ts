import { NgModule } from '@angular/core';
import { NgAlainModule } from '@fs/ng-alain';
import { CoreModule as AbpCoreModule } from '@abp/ng.core';
import { environment } from '../../environments/environment';
import { NgxsLoggerPluginModule } from '@ngxs/logger-plugin';
import { NgxsModule } from '@ngxs/store';
import { AccountConfigModule } from '@abp/ng.account.config';
import { IdentityConfigModule } from '@abp/ng.identity.config';
import { TenantManagementConfigModule } from '@abp/ng.tenant-management.config';
import { SettingManagementConfigModule } from '@fs/setting-management/config';
import {CodingManagementConfigModule} from '@fs/coding-management/config';
import { JobsManagementConfigModule } from '@fs/jobs-management/config'



const LOGGERS = [NgxsLoggerPluginModule.forRoot({ disabled: false })];
const AbpConfigModules=[
  AbpCoreModule.forRoot({
    environment
  }),
  AccountConfigModule.forRoot({ redirectUrl: '/' }),
  IdentityConfigModule,
  TenantManagementConfigModule,
  SettingManagementConfigModule,
  CodingManagementConfigModule,
  JobsManagementConfigModule
]


@NgModule({
  declarations: [
  ],
  imports: [
    ...AbpConfigModules,
    NgxsModule.forRoot([]),
    ...(environment.production ? [] : LOGGERS),
    NgAlainModule.forRoot()
  ],
  exports: [

  ],
  providers: []

})
export class CoreModule { }
