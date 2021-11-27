import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SalescoComponent } from '../salesco/salesco.component';
import { Visit } from './visit'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalesService {

  formData: Visit = new Visit();
  visit: Visit[];


  constructor(
    private httpClient: HttpClient
  ) { }

  //Insert employee
  insertVisit(visit: Visit): Observable<any> {
    return this.httpClient.post(environment.apiUrl + "/api/post/addsales", visit);
  }

  //update
  updateVisit(visit: Visit): Observable<any> {
    return this.httpClient.put(environment.apiUrl + "/api/post/putvisit", visit);

  }

   //get all employees
   bindListVisit() {
    this.httpClient.get(environment.apiUrl + "/api/post/getallvisit")
      .toPromise().then(

        Response => this.visit = Response as Visit[]
      )
  }

  //DELETE 
  deleteVisit(id: number) {
    return this.httpClient.delete(environment.apiUrl + "/api/post/delemp?id=" + id);

  }

  
}
