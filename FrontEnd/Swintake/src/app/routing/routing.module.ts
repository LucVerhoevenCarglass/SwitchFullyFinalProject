import { NgModule } from '@angular/core';
import {RouterModule, Routes} from '@angular/router'
import { LoginComponent } from '../feature/login/login.component';
import { JobApplicationsComponent } from '../feature/job-applications/job-applications.component';
import { CampaignCreateComponent } from '../feature/campaigns/campaign-create/campaign-create.component';
<<<<<<< HEAD
import { CampaignListComponent } from '../feature/campaigns/campaign-list/campaign-list.component';
=======
import { AuthGuard } from '../core/authentication/auth.guard';
>>>>>>> 8f188e6143992467f4ef1ffb472ba14087f6d13e

const routes: Routes=[
  {path: '', redirectTo: '/login', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
<<<<<<< HEAD
  {path: 'jobapplications', component: JobApplicationsComponent},
  {path: 'createcampaign', component: CampaignCreateComponent},
  {path: 'listcampaigns', component: CampaignListComponent}
=======
  {path: 'jobapplications', component: JobApplicationsComponent, canActivate: [AuthGuard]},
  {path: 'createcampaign', component: CampaignCreateComponent, canActivate: [AuthGuard]}
>>>>>>> 8f188e6143992467f4ef1ffb472ba14087f6d13e
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
