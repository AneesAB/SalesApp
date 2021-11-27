import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Route, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  canActivate(
    next: ActivatedRouteSnapshot): boolean {
      //expected role and current role comparison
      const expectedRole = next.data.rId;
      const currentRole = localStorage.getItem('ACCESS_ROLE');

      //chek the condition
      if(currentRole !== expectedRole){
        this.router.navigateByUrl('login');
        return false;
      }
    return true;
  }
  
}
