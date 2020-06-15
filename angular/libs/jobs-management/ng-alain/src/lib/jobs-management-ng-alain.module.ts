import { NgModule } from '@angular/core';
import { NgAlainBasicModule } from '@fs/ng-alain/basic';
import { SharedModule } from './shared/shared.module';
import { SampleModule } from './sample/sample.module';
import { Store } from '@ngxs/store';
import { AddRoute,ABP } from '@abp/ng.core';
import { JobsManagementModule } from '@fs/jobs-management';
import { JobsManagementNgAlainRoutingModule } from './jobs-management-ng-alain-routing.module';

@NgModule({
  imports: [
    SharedModule,
    JobsManagementModule,
    JobsManagementNgAlainRoutingModule,
    SampleModule

  ]
})
export class JobsManagementNgAlainModule {
}
