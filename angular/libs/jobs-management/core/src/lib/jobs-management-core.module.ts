import { NgModule } from '@angular/core';
import { ThemeCoreModule } from '@fs/theme.core';

@NgModule({
  imports: [ThemeCoreModule],
  exports: [ThemeCoreModule]
})
export class JobsManagementCoreModule { }
