import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { SalesService } from 'src/app/shared/sales.service';
import { DatePipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { Visit } from 'src/app/shared/visit';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.scss']
})
export class SalesComponent implements OnInit {

  visitid:number;
  visit: Visit = new Visit();

  constructor(
    public salesService: SalesService,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.visitid = this.route.snapshot.params['visitId'];

    
      
  }

  //clear contetns at initialization
  resetform(form?: NgForm) {
    if (form != null) {
      form.resetForm();
    }
  }

  //Insert
  insertSalesRecord(form?: NgForm) {
    console.log("Inserting a record");
    this.salesService.insertVisit(form.value).subscribe(
      (result) => {
        console.log(result);
        this.resetform(form);
      }
    );
    window.location.reload();
  }

  //UPDATE
  updateEmployeeRecord(form: NgForm) {
    console.log("Updating a record...."); // For testing
    console.log(form.value);
    this.salesService.updateVisit(form.value).subscribe(

      (result) => {
        console.log(result);
        this.resetform(form);
        this.salesService.bindListVisit();
      }
    );
    window.location.reload();
  }
}


