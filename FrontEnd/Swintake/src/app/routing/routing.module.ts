import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router'
import { LoginComponent } from '../feature/login/login.component';
import { JobApplicationsComponent } from '../feature/job-applications/job-applications.component';
import { CampaignCreateComponent } from '../feature/campaigns/campaign-create/campaign-create.component';
import { CampaignListComponent } from '../feature/campaigns/campaign-list/campaign-list.component';
import { AuthGuard } from '../core/authentication/auth.guard';

const routes: Routes=[
  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'listcampaigns', component: CampaignListComponent, canActivate: [AuthGuard]},
  {path: 'jobapplications', component: JobApplicationsComponent, canActivate: [AuthGuard]},
  {path: 'createcampaign', component: CampaignCreateComponent, canActivate: [AuthGuard]}

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
