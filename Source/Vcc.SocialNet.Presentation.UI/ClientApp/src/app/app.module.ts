import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
//import { ContentLayoutComponent } from './shared/layout/content-layout/content-layout.component';

// instead of individual sub-module imports, use Barrel to import all sub modules
import {  ContactModule,
          CourseModule,
          DailyBreadModule,
          GeneralModule,
          HomeModule,
          MessageModule,
          PrayerModule
        } from './modules'; 
import { SharedModule } from './shared/shared.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HttpClientModule } from '@angular/common/http';
import { CoreModule } from './core';
// for advanced animations
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { MaterialModule } from './shared/material.module';

@NgModule({
  declarations: [
    AppComponent,    
    // // two main layout components as below
    // ContentLayoutComponent, // used for pages once user is authenticated (nav bar with secure application content)
    // AuthLayoutComponent // used for pages that don't require authorization (no nav bar, no secure application content)

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,

    //FormsModule,    
    FontAwesomeModule, // used in AuthLayoutComponent
    SharedModule,
    AppRoutingModule,
    HttpClientModule,
    // sub-modules
    CoreModule,
    ContactModule,
    CourseModule,
    DailyBreadModule,
    GeneralModule,
    HomeModule,
    MessageModule,
    PrayerModule
  ],
  providers: [
    Title
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
