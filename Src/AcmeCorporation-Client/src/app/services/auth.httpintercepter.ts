import { Injectable } from '@angular/core';
import { HttpRequest,HttpHandler,HttpEvent,HttpInterceptor} from '@angular/common/http';
import { Observable } from '../../../node_modules/rxjs';
import { UserService } from './user.service';


// service has not been registered! If we were to finally implement login we needed to attach the bearer
// authentication token on each request! This class intercepts the outgoing http call and attach
// the header if we are logged in

@Injectable()
export class HttpAccessTokenInterceptor implements HttpInterceptor {

  constructor(private userService: UserService){ }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const accessInfo = this.userService.getAcccessInfo();
    if (accessInfo.isLoggedIn){
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${accessInfo.accessToken}`
        }
      });
    }
    return next.handle(request);
  }
}
