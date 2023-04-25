import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import UserService from '../service/user.service';

@Injectable()
export class FirstInterceptor implements HttpInterceptor {

  constructor(private us:UserService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = localStorage.getItem('token');
    if(token){
       request = request.clone({
       setHeaders:{Authorization:`Bearer ${token}`}
        })
    }
    return next.handle(request);
  }
}
