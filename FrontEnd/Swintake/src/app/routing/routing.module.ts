import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router'
import { LoginComponent } from '../feature/login/login.component';
import { JobApplicationsComponent } from '../feature/job-applications/job-applications.component';
import { CampaignCreateComponent } from '../feature/campaigns/campaign-create/campaign-create.component';

const routes: Routes=[
  {path: '', redirectTo: '/home', pathMatch: 'full' },
  {path: 'login', component: LoginComponent},
  {path: 'jobapplications', component: JobApplicationsComponent},
  {path: 'createcampaign', component: CampaignCreateComponent}
];

@NgModule({
  exports: [
    RouterModule],
  imports: [
    RouterModule.forRoot(routes)
  ]
})
export class RoutingModule { }
