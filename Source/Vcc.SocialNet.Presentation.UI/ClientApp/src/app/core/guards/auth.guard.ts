import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

/**
 * Router guard to ensure the current user is authenticated
 */
@Injectable()
export class AuthGuard implements CanActivate {
    
    constructor(private authService : AuthService, private router : Router) {}
    canActivate(): boolean {
        if(this.authService.isAuthenticated) {
            return true;
        }
        else {
            this.router.navigate(['/auth/login']);
            return false;
        }
    }
}
