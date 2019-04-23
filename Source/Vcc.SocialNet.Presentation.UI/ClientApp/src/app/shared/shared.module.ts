import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContentLayoutComponent } from './layout/content-layout/content-layout.component';
import { AuthLayoutComponent } from './layout/auth-layout/auth-layout.component';
import { FooterComponent } from './layout/footer/footer.component';
import { TopMenuComponent } from './layout/top-menu/top-menu.component';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { ModalComponent } from './components/modal/modal.component';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { ControlMessagesComponent } from './components/control-messages/control-messages.component';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaterialModule } from './material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { SpinnerDialogComponent } from './components/spinner-dialog/spinner-dialog.component';
import { SpinnerDialogContentComponent } from './components/spinner-dialog/spinner-dialog-content.component';
//import { SpinnerDialogContentComponent } from './components/spinner-dialog/spinner-dialog-content.component';

@NgModule({
  declarations: [
    ContentLayoutComponent, AuthLayoutComponent, 
    FooterComponent, TopMenuComponent, SidebarComponent, TopMenuComponent, ModalComponent, 
    ControlMessagesComponent, SpinnerDialogComponent, SpinnerDialogContentComponent],
  imports: [
    CommonModule,
    FontAwesomeModule,
    MaterialModule,
    RouterModule, //need to import this in every custom module that requires routing
    FlexLayoutModule
  ],
  exports: [
    ContentLayoutComponent, AuthLayoutComponent, 
    FooterComponent, TopMenuComponent, SidebarComponent, TopMenuComponent, 
    ControlMessagesComponent, SpinnerDialogComponent, SpinnerDialogContentComponent
  ],
  entryComponents: [
    SpinnerDialogContentComponent
  ]  
})
export class SharedModule { }
// make Layout components available in ts classes as well
export {ContentLayoutComponent, AuthLayoutComponent, SpinnerDialogComponent};