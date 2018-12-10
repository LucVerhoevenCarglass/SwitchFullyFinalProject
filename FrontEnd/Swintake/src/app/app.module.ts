import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component'; 
import { CoreModule } from './core/core.module';
import { RoutingModule } from './routing/routing.module';
import { FeatureModule } from './feature/feature.module';
import { SharedModule } from './shared/shared.module';
import { HeaderComponent } from './header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent
  ],
  
  imports: [
    BrowserModule,
    CoreModule,
    RoutingModule,
    FeatureModule,
    SharedModule
  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
