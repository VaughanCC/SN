import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DailyBreadRoutingModule } from './daily-bread-routing.module';
import { DailyBreadsComponent } from './pages/daily-breads/daily-breads.component';
import { DailyBreadDetailComponent } from './pages/daily-bread-detail/daily-bread-detail.component';

@NgModule({
  declarations: [DailyBreadsComponent, DailyBreadDetailComponent],
  imports: [
    CommonModule,
    DailyBreadRoutingModule
  ]
})
export class DailyBreadModule { }
