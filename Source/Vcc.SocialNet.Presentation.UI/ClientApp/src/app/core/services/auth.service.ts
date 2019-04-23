import { Injectable } from '@angular/core';
import { of, Observable, throwError } from 'rxjs';

import { User } from '../../core/models';
import { HttpClient } from '@angular/common/http';
import { JsonApiService } from './json-api.service';
import { map, tap } from 'rxjs/operators';
import { AuthResponse } from '../models/auth.model';

export class ILoginContext {
  username: string;
  password: string;
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private auth_token: string;
  //private loggedIn : boolean
  constructor(private apiService: JsonApiService ) {
    this.auth_token = null;
    //this.loggedIn = false;
   }

  /**
   * Authenticates a user
   * @param loginContext 
   */
  login(loginContext: ILoginContext): Observable<any> {
    var url: string = "auth/authenticate/";
    var requestData = { 
      UserName: loginContext.username,
      Password: loginContext.password
    }
    var obs = this.apiService.post(url, requestData)
        .pipe(
          tap(response => this.handleLogin(response))
        );      
    return obs;
    // return throwError('Invalid username or password');
  }

  private handleLogin(response : AuthResponse) : void {
    if(response != null && response.Success) {
      this.auth_token = response.Success ? response.Token : null; 
      //this.loggedIn = true;
    }      
    else {
      this.auth_token = null; 
      //this.loggedIn = false;
    }
  }

  logout(): Observable<boolean> {
    this.auth_token = null;
    return of(false);
  }

  getToken() {
    return this.auth_token;
  }

  get isAuthenticated() : boolean {
    return (this.auth_token != null && this.auth_token.length > 0);
  }
}
