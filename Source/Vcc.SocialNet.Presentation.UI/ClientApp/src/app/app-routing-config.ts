
import { Routes } from '@angular/router'
import { InvalidPageComponent } from './modules/general/pages/invalid-page/invalid-page.component';
import { AuthGuard } from './core';
import { CONTENT_ROUTES } from './shared/routes/content-layout.routes';
import { ContentLayoutComponent, AuthLayoutComponent } from './shared/shared.module';

/**
 * Application Route Configuration  
 */
export const appRouteConfig:Routes = [
    // matches '/' as long as the route can be activated (authenticated)
    {
        path: '',
        component: ContentLayoutComponent,
        canActivate: [AuthGuard], // Should be replaced with actual auth guard
        children: CONTENT_ROUTES
    },
    // AuthModule is configured for lazy-load as below
    {
        path: 'auth',
        component: AuthLayoutComponent,
        loadChildren: './modules/auth/auth.module#AuthModule'
    },
    // GeneralModule is configured for lazy-load as below
    {
        path: 'general',
        component: AuthLayoutComponent,
        loadChildren: './modules/general/general.module#GeneralModule'
    },
    // Fallback when no prior routes is matched
    { 
        path: '**', redirectTo: 'general/invalid', pathMatch: 'full' 
    }
];