import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { SharedModule } from '@app/shared/shared.module'
import { AuthRoutingModule } from './auth.routing';
import { ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule } from '@angular/forms';

import { MaterialModule } from '@app/shared/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    CommonModule,    
    AuthRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FontAwesomeModule,
    FormsModule,
    MaterialModule,
    FlexLayoutModule
  ]  
})
export class AuthModule { }
