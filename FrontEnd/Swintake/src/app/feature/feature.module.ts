import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '../core/core.module';
import { RoutingModule } from '../routing/routing.module';
import { LoginComponent } from './login/login.component';
import { JobApplicationsComponent } from './job-applications/job-applications.component';
import { CampaignComponent } from './campaign/campaign.component';
import { CampaignsComponent } from './campaigns/campaigns.component';
import { CampaignDetailComponent } from './campaigns/campaign-detail/campaign-detail.component';

@NgModule({
  declarations: [
    LoginComponent, 
    JobApplicationsComponent, CampaignComponent, CampaignsComponent, CampaignDetailComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    RoutingModule,
  ],
})
export class FeatureModule { }
