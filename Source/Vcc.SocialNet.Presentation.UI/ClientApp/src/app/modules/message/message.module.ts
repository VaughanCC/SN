import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MessageRoutingModule } from './message-routing.module';
import { MessagesComponent } from './pages/messages/messages.component';
import { MessageDetailComponent } from './pages/message-detail/message-detail.component';
import { MessageSearchComponent } from './pages/message-search/message-search.component';

@NgModule({
  declarations: [MessagesComponent, MessageDetailComponent, MessageSearchComponent],
  imports: [
    CommonModule,
    MessageRoutingModule
  ]
})
export class MessageModule { }
