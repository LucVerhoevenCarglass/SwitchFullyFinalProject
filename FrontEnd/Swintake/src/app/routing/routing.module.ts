import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router'
import { LoginComponent } from '../feature/login/login.component';
import { JobApplicationsComponent } from '../feature/job-applications/job-applications.component';

const routes: Routes=[
  {path: 'login', component: LoginComponent},
  {path: 'jobapplications', component: JobApplicationsComponent}
];

@NgModule({
  exports: [
    RouterModule],
  imports: [
    RouterModule.forRoot(routes)
  ]
})
export class RoutingModule { }
