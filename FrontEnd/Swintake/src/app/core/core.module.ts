import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CampaignService } from './campaigns/services/campaign.service';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from '../core/authentication/services/auth.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AuthGuard } from './authentication/helpers/auth.guard';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  exports:[
    CommonModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers:[
    CampaignService,
    AuthService,
    AuthGuard
  ]

})
export class CoreModule { }
