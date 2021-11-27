import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../shared/user';
import { AuthService } from '../shared/auth.service';
import { Jwtresponse } from '../shared/jwtresponse';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  isSubmitted = false;
  loginUser: User = new User();
  error='';
  jwtresponse: any = new Jwtresponse();

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    //FormGroup
    this.loginForm = this.formBuilder.group(
      {
        Username: ['', [Validators.required, Validators.minLength(2)]],
        Password: ['', [Validators.required]]
      }
    );
  }

  //get controls
  get formControls() {
    return this.loginForm.controls;
  }

  loginCredentials(){
     //valid or invalid
     this.isSubmitted = true;
     console.log(this.loginForm.value);

     if (this.loginForm.invalid) {
      console.log("invalid");
     }

      if (this.loginForm.valid) {

        //calling method from authserive Authenticate and authorization
        this.authService.loginVerify(this.loginForm.value)
          .subscribe(data => {
            console.log(data);
  
            this.jwtresponse = data;
            //console.log(this.jwtresponse.token);
            //
  
            //check the role--based on TroleId, it redirects to the route
            if (this.jwtresponse.rId == 'admin') {
              //logged in as admin
              console.log("Admin");
              //storing in local storage
              localStorage.setItem("username", this.jwtresponse.UName);
              localStorage.setItem("ACCESS_ROLE", this.jwtresponse.rId.toString());
              sessionStorage.setItem("jwtToken", this.jwtresponse.token);
              sessionStorage.setItem("username", this.jwtresponse.UName);
              console.log("routing");
              this.router.navigateByUrl('admin');
            }
            else if (this.jwtresponse.rId == 'SalesCoordinator') {
              console.log("Manager");
              localStorage.setItem("username", this.jwtresponse.UName);
              localStorage.setItem("ACCESS_ROLE", this.jwtresponse.rId.toString());
              sessionStorage.setItem("jwtToken", this.jwtresponse.token);
              sessionStorage.setItem("username", this.jwtresponse.UName);
              this.router.navigateByUrl('sales');
            }
            else {
              this.error = "Sorry Not allowed...Invalid Authorization !!!"
            }
          },
            error => {
              this.error = "Invalid username or password";
            }
          )
    }
  }

}
