import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(
    private authService: AuthService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<any>> {
    //sendng next
    console.log('interception activated');
    let token = sessionStorage.getItem('jwtToken');
    if(sessionStorage.getItem('username') && sessionStorage.getItem('jwtToken')){
      request=request.clone(
        {
          setHeaders:{
            Autorization: `Bearer ${token}`
          }
        }
      )
    }
    return next.handle(request);
  }
}
