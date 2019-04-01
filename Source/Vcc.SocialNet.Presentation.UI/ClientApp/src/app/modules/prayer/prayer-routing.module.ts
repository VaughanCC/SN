import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PrayersComponent } from './pages/prayers/prayers.component';
import { PrayerDetailComponent } from './pages/prayer-detail/prayer-detail.component';

const prayerRoutes: Routes = [
  {
    path: 'prayers',
    component: PrayersComponent
  },
  {
    path: 'prayers/:id',    
    component: PrayerDetailComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(prayerRoutes)],
  exports: [RouterModule]
})
export class PrayerRoutingModule { }
