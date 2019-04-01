import { Injectable } from '@angular/core';
import { of, Observable, throwError } from 'rxjs';

import { User } from '../../core/models';
import { HttpClient } from '@angular/common/http';
import { JsonApiService } from './json-api.service';

export class ILoginContext {
  username: string;
  password: string;
  token: string;
}

const defaultUser : User = {
  username: 'Mathis',
  password: '12345',
  token: '12345'
};


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  token: string;

  constructor(private apiService: JsonApiService ) { }

  /**
   * Authenticates a user
   * @param loginContext 
   */
  login(loginContext: ILoginContext): Observable<User> {
    return apiService.fetch("api/v1/ShowUserByID")
    
    // if ( 
    //   loginContext.username === defaultUser.username &&
    //   loginContext.password === defaultUser.password) {
    //     return of(defaultUser);
    // }

    return throwError('Invalid username or password');
  }

  logout(): Observable<boolean> {
    return of(false);
  }

  getToken() {
    return this.getToken;
  }
}
