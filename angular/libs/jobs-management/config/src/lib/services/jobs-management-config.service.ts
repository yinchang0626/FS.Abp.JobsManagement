import { addAbpRoutes, RestService, ConfigStateService, eLayoutType } from '@abp/ng.core';
import { Injectable, Injector } from '@angular/core';
import { Router } from '@angular/router';
import { ThemeCoreService, IConfigService } from '@fs/theme.core';
import { Observable, concat } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class JobsManagementConfigService  implements IConfigService{
  get configStateService(): ConfigStateService {
    return this.injector.get(ConfigStateService);
  }
  get themeCoreService(): ThemeCoreService {
    return this.injector.get(ThemeCoreService);
  }

  private JobsManagement_route = [{
    name: 'JobsManagement',
    path: 'jobs-management',
    iconClass: 'fa fa-folder',
    layout: eLayoutType.application,
    profile: {
      title: 'JobsManagement',
      doc: 'JobsManagement',
      nav: { routeName: 'JobsManagement' }
    },
    children: [
      {
        path: 'sample', name: 'Sample', iconClass: 'fa fa-university', order: 1,
        children: []
      },
    ]
  }];
  constructor(private injector: Injector) {}
  registerRoutes(): Observable<any> {
    //FS: If you want to add extract path at administrator  menu
    //var adminRoute = this.configStateService.getRoute(null, 'AbpUiNavigation::Menu:Administration');
    //adminRoute.children.push(this.admin_route);
    
    return concat(
      //this.themeCoreService.dispatchAddOrPatchRoute(adminRoute),
      this.themeCoreService.dispatchAddOrPatchRoute(this.JobsManagement_route[0])
    );
  }
}
