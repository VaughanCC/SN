import { Component, OnInit, ViewChild, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { tap, delay, finalize, catchError } from 'rxjs/operators';
import { of, Observable, PartialObserver, Subscription } from 'rxjs';

import { AuthService, ILoginContext } from '@app/core/services/auth.service';
import { SpinnerDialogComponent } from '@app/shared/shared.module';
import { MatDialog } from '@angular/material';
import { User } from '@app/core';
import { AuthResponse } from '@app/core/models/auth.model';

//import { faUserCircle } from '@fortawesome/free-solid-svg-icons';
//import { User } from '@app/core';
//import { MaterialModule } from '@app/Shared/material.module';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  error: string;
  isLoggingIn: boolean;
  loginForm: FormGroup;

  // We can add the directive <spinner-dialog></spinner-dialg> to html if we want to use ViewChild instead of instatiing the component from ts code
  // @ViewChild(SpinnerDialogComponent)
  // private spinnerDlg : SpinnerDialogComponent;
  
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private zone: NgZone) {
    this.buildForm();        
  }

  ngOnInit() {}

  get f () {
    return this.loginForm.controls;
  }

  login(): Subscription {
    this.isLoggingIn = true;

    const formValue = this.loginForm.value;

    const credentials: ILoginContext = new ILoginContext();
    credentials.username = formValue.username;
    credentials.password = formValue.password;    

    const userObs = this.authService.login(credentials)
      .pipe(
        delay(1000),
        // tap(user => this.router.navigate()),
        finalize(() => this.isLoggingIn = false),
        catchError(error => of(this.error = error))
      ); 
    const userSub = userObs.subscribe(response => this.handleLogin(response));
                                      // error => this.error = error.message);

    // instead of displaying spinning icon inside the button, display a spinner dialog while authenticating the user credentials
    //this.spinnerDlg.displaySpinner(userObs);
    return userSub;
  }

  private handleLogin(response : any) : void {
    if(response != null) { 
      if(response.Success) {
        this.router.navigate(['/']);
      }
      else {
        this.error = "The credentials you have entered are incorrect.";
      }
    }      
    else {
      this.error = "An error occurred during authentication.";
    }
  }

  private buildForm(): void {
    this.loginForm = this.formBuilder.group({
        username: [{value:'', disabled: false}, Validators.required],
        password: [{value:'', disabled: false}, Validators.required],
        rememberLogin: [true]
    });    
  }

  
}
