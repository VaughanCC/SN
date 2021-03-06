import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';

/**
 * Route configuration for Home module
 */
export const routes : Routes = [
  {
    path: 'home',
    component: HomeComponent,    
  },
  {
    path: '**', redirectTo: ''
  }  
];

/**
 * Home Routing Module
 */
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HomeRoutingModule { }
