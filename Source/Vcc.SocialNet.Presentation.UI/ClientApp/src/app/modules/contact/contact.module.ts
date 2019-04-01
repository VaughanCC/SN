import { NgModule } from '@angular/core';
import { ContactsComponent } from './pages/contacts/contacts.component';
import { ContactDetailComponent } from './pages/contact-detail/contact-detail.component';
import { ContactSearchComponent } from './pages/contact-search/contact-search.component';
/**
 * Contact Module
 * 
 * This module package up all components related to the Contact section. Routing definition for the Contact section is defined in {@link ContactRoutingModule}
 */
@NgModule({
    declarations: [        
    ContactsComponent, ContactDetailComponent, ContactSearchComponent],
    imports: [
    ],
    exports: [],
    providers: [],
    entryComponents: [ContactsComponent]
})
export class ContactModule {}
