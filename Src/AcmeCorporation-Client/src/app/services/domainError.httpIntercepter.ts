import { Injectable } from '@angular/core';
import { HttpRequest,HttpHandler,HttpEvent,HttpInterceptor, HttpErrorResponse} from '@angular/common/http';
import { Observable, of } from '../../../node_modules/rxjs';
import { UserService } from './user.service';
import {catchError} from "rxjs/internal/operators";



@Injectable()
export class DomainErrorInterceptor implements HttpInterceptor {

  constructor(private userService: UserService){ }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(request)
      .pipe(catchError((error, caught) => {
        if (error.status === 400) {
      
          // Do toast message if the error is a domain error
    
          return of(error);
        }
      }) as any);
  }
}
