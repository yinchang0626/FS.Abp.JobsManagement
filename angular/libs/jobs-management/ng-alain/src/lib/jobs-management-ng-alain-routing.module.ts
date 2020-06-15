import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DynamicLayoutComponent } from '@abp/ng.core';
import * as modules from './modules';

const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: 'sample' },
    {
        path: '',
        component: DynamicLayoutComponent,
        //canActivate: [AuthGuard, PermissionGuard],
        children: [
            modules.SampleModuleRoute()
        ],
    }
];
// @dynamic
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class JobsManagementNgAlainRoutingModule { }
