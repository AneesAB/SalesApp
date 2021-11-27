import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from './user';
import { Observable } from 'rxjs';
import { environment } from "src/environments/environment"

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private httpClient: HttpClient,
    private router: Router
  ) { }

  //Get the user
  getUserByPassword(user: User): Observable<any>{
    console.log(user.Username);
    console.log(user.Password);
    return this.httpClient.get(environment.apiUrl+"/api/login/getuser/" + user.Username + "/" + user.Password);
  }
  //https://localhost:44345/api/login/anees/pass

  public loginVerify(user: User): Observable<any>{
    console.log("authorizing...");
    console.log(user);
    return this.httpClient.get(environment.apiUrl+"/api/login/"+ user.Username+"/"+user.Password);
  }

  //logout
  public logOut(){
    localStorage.removeItem('username');
    localStorage.removeItem('ACCESS_ROLE');
    sessionStorage.removeItem('username');
    sessionStorage.removeItem('jwtToken');
  }
}
