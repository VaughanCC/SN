import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContactsComponent } from './pages/contacts/contacts.component';
import { ContactDetailComponent } from './pages/contact-detail/contact-detail.component';
import { ContactSearchComponent } from './pages/contact-search/contact-search.component';

/**
 * Route configuration for Home module
 */
export const contactRoutes : Routes = [
  {
    path: '',
    component: ContactsComponent
  },
  {
    path: ':id',
    component: ContactDetailComponent
  },
  {
    path: 'search',
    component: ContactSearchComponent
  }
];

/**
 * Contact Routing Module
 */
@NgModule({
    imports: [RouterModule.forChild(contactRoutes)],
    exports: [RouterModule]
})
export class ContactRoutingModule { }
