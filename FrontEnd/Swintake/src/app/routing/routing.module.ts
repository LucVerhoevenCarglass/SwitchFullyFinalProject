import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router'
import { LoginComponent } from '../feature/login/login.component';
import { JobApplicationsComponent } from '../feature/job-applications/job-applications.component';
import { CampaignCreateComponent } from '../feature/campaigns/campaign-create/campaign-create.component';
import { CampaignListComponent } from '../feature/campaigns/campaign-list/campaign-list.component';

const routes: Routes=[
  {path: '', redirectTo: '/home', pathMatch: 'full' },
  {path: 'login', component: LoginComponent},
  {path: 'jobapplications', component: JobApplicationsComponent},
  {path: 'createcampaign', component: CampaignCreateComponent},
  {path: 'listcampaigns', component: CampaignListComponent}
];

@NgModule({
  exports: 
  [
    RouterModule
  ],
  imports: 
  [
    RouterModule.forRoot(routes)
  ]
})
export class RoutingModule { }
