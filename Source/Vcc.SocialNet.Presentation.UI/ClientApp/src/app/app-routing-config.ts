
import { Routes } from '@angular/router'
import { ContentLayoutComponent } from './layouts/content-layout/content-layout.component';
import { InvalidPageComponent } from './modules/general/pages/invalid-page/invalid-page.component';
import { NoAuthGuard } from './core';
import { CONTENT_ROUTES } from './shared/routes/content-layout.routes';
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
/**
 * Application Route Configuration  
 */
export const appRouteConfig:Routes = [
    // default route: display login screen
    {
        path: '',
        redirectTo: '/auth/login',
        pathMatch: 'full'
    },
    // matches all routs except ('/' - default route) as long as the route can be activated (authenticated)
    {
        path: '',
        component: ContentLayoutComponent,
        canActivate: [NoAuthGuard], // Should be replaced with actual auth guard
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
    { path: '**', redirectTo: 'general/invalid', pathMatch: 'full' 
    }
];