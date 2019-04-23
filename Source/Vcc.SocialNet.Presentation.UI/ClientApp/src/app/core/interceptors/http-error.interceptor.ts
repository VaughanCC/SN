import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpResponse,
    HttpErrorResponse
   } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
   

/**
 * Represents a HttpInterceptor that handles Http errors. 
 */
export class HttpErrorInterceptor implements HttpInterceptor {

    /**
     * This implents the intercept function defined by HttpInterceptor
     * This is used to handle all error related to http request.
     */
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request)
            .pipe(
                retry(1),
                catchError((error: HttpErrorResponse) => {
                let errorMessage = '';
                if (error.error instanceof ErrorEvent) {
                    // client-side error
                    errorMessage = `Error: ${error.error.message}`;
                } else {
                    // server-side error
                    errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
                }
                //window.alert(errorMessage);
                return throwError(errorMessage);
                })
            );
    }
}