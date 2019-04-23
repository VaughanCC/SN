import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { config } from '../app-config';

import { delay, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class JsonApiService {

    constructor(private httpClient: HttpClient) { }

    fetch(url: string): Observable<any> {
        let reqUrl = config.API_URL + url;
        
        return this.httpClient.get(reqUrl, { headers: this.getHeaders() });
            // .pipe(
            //     delay(100),
            //     catchError(this.handleError)
            // );
    }

    post(url: string, data: any)  : Observable<any>{
        var reqUrl = config.API_URL + url;
        return this.httpClient.post(reqUrl, data, { headers: this.getHeaders() });
    }

    private getBaseUrl() {
        // if API resides in the same host where Angular app is running
        return `${location.protocol}//${location.hostname + (location.port ? ':' + location.port : '')}/`;        
    }

    private handleError(error: any) {
        const errorMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';

        return throwError(errorMsg);
    }

    private getHeaders() : HttpHeaders {
        let headers = new HttpHeaders();
        // set api-version header
        headers = headers.append('api-version', config.API_VERSION);        
        return headers;
    }

}
