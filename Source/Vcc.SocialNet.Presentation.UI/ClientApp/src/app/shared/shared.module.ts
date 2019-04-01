import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FooterComponent } from './layout/footer/footer.component';
import { TopMenuComponent } from './layout/top-menu/top-menu.component';
import { SidebarComponent } from './layout/sidebar/sidebar.component';
import { ModalComponent } from './components/modal/modal.component';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { ControlMessagesComponent } from './components/control-messages/control-messages.component';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [FooterComponent, TopMenuComponent, SidebarComponent, TopMenuComponent, ModalComponent, ControlMessagesComponent, SpinnerComponent],
  imports: [
    CommonModule,
    FontAwesomeModule,
    RouterModule //need to import this in every custom module that requires routing
  ],
  exports: [
    FooterComponent, TopMenuComponent, SidebarComponent, TopMenuComponent, ControlMessagesComponent, SpinnerComponent    
  ]  
})
export class SharedModule { }
