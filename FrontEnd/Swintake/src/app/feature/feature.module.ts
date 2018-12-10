import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '../core/core.module';
import { RoutingModule } from '../routing/routing.module';
import { LoginComponent } from './login/login.component';
import { JobApplicationsComponent } from './job-applications/job-applications.component';

@NgModule({
  declarations: [
    LoginComponent, 
    JobApplicationsComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    RoutingModule,
  ],
})
export class FeatureModule { }
