import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DailyBreadsComponent } from './pages/daily-breads/daily-breads.component';
import { DailyBreadDetailComponent } from './pages/daily-bread-detail/daily-bread-detail.component';

const dailyBreadRoutes: Routes = [
  {
    path: '',
    component: DailyBreadsComponent
  },
  {
    path: ':id',    
    component: DailyBreadDetailComponent
  }  
];

@NgModule({
  imports: [RouterModule.forChild(dailyBreadRoutes)],
  exports: [RouterModule]
})
export class DailyBreadRoutingModule { }
