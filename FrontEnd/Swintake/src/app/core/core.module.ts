import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from './users/user.service';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import {MomentModule} from 'ngx-moment';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MomentModule
  ],
  exports:[
    CommonModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
  MomentModule],
  providers:[UserService]
})
export class CoreModule { }
