import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { appRouteConfig } from './app-routing-config';

@NgModule({
  imports: [RouterModule.forRoot(
    appRouteConfig,
    {enableTracing: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
