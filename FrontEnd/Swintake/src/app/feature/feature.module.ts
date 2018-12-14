import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '../core/core.module';
import { RoutingModule } from '../routing/routing.module';
import { LoginComponent } from './login/login.component';
import { JobApplicationsComponent } from './job-applications/job-applications.component';
import { CampaignDetailComponent } from './campaigns/campaign-detail/campaign-detail.component';
import { CampaignCreateComponent } from './campaigns/campaign-create/campaign-create.component';
import { CampaignListComponent } from './campaigns/campaign-list/campaign-list.component';
import { NgbdModalContent } from '../feature/login/login.component';
import { CandidateCreateComponent } from './candidates/candidate-create/candidate-create.component';
import { CandidateListComponent } from './candidates/candidate-list/candidate-list/candidate-list.component';

@NgModule({
  declarations: [
    LoginComponent, 
    JobApplicationsComponent, 
    CampaignDetailComponent, 
    CampaignCreateComponent, 
    CampaignListComponent, 
    NgbdModalContent, 
    CandidateCreateComponent, 
    CandidateListComponent
  ],
  entryComponents:[NgbdModalContent],
  imports: [
    CommonModule,
    CoreModule,
    RoutingModule
  ],
})
export class FeatureModule { }
