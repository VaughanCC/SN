import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { appRouteConfig } from './app-routing-config';

@NgModule({
  imports: [RouterModule.forRoot(
    appRouteConfig,
    // enable tracing so that we can debug the routing problems : DO NOT forget to set to false when deploying to PROD
    {enableTracing: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
