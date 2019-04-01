import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrayerRoutingModule } from './prayer-routing.module';
import { PrayersComponent } from './pages/prayers/prayers.component';
import { PrayerDetailComponent } from './pages/prayer-detail/prayer-detail.component';

@NgModule({
  declarations: [PrayersComponent, PrayerDetailComponent],
  imports: [
    CommonModule,
    PrayerRoutingModule
  ]
})
export class PrayerModule { }
