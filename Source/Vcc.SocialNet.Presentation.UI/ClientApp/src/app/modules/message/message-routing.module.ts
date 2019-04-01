import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MessageSearchComponent } from './pages/message-search/message-search.component';
import { MessagesComponent } from './pages/messages/messages.component';
import { MessageDetailComponent } from './pages/message-detail/message-detail.component';

const mesageRoutes: Routes = [
  {
    path: '',
    component: MessagesComponent
  },
  {
    path: ':id',
    component: MessageDetailComponent
  },
  {
    path: 'search',    
    component: MessageSearchComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(mesageRoutes)],
  exports: [RouterModule]
})
export class MessageRoutingModule { }
