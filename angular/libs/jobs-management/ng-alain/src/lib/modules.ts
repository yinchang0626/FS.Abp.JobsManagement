import { SampleModule } from './sample/sample.module';
export function SampleModuleRoute() {
  return {
    path: 'sample',
    loadChildren: loadSampleModule,
  };
}
export function loadSampleModule() {
  return SampleModule;
}