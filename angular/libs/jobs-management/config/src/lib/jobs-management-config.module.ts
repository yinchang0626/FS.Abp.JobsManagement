

import { InitConfigService } from '@fs/theme.core';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { JobsManagementConfigService } from './services/jobs-management-config.service';

@NgModule({
  providers: [{ provide: APP_INITIALIZER, deps: [JobsManagementConfigService], useFactory: InitConfigService, multi: true }],
})
export class JobsManagementConfigModule {}
