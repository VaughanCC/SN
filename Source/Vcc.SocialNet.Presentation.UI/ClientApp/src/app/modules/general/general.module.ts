import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GeneralRoutingModule } from './general-routing.module';
import { InvalidPageComponent } from './pages/invalid-page/invalid-page.component';

@NgModule({
  declarations: [InvalidPageComponent],
  imports: [
    CommonModule,
    GeneralRoutingModule
  ]
})
export class GeneralModule { }
