import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { InvalidPageComponent } from './pages/invalid-page/invalid-page.component'

const routes: Routes = [
    {
        path: '',
        redirectTo: 'invalid',
        pathMatch: 'full'
    },
    {
        path: 'invalid',
        component: InvalidPageComponent
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GeneralRoutingModule { }
