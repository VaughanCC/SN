import { async, ComponentFixture, TestBed, fakeAsync, tick, getTestBed, inject } from '@angular/core/testing';
import { LoginComponent } from './login.component';

////////////////////////////////////////////////////////////////////////////////
// The folloiwng import modules are needed for most of the unit  tests 
// Need the following to resolve a problem with an error with [Object Object] not found error: usually this refers to the fact that Routing module not imported
import { RouterModule, Router } from '@angular/router';
// Need the folloiwng to resolve an error with "can't bind to 'control' as it is unknown property of 'app-control-mesage'
import { SharedModule } from '@app/shared/shared.module';
// Need the following to resolve an error related to "staticInjectorError(DynamicTestModule)[RouterOutlet -> ChildrenOutletContexts]"
import { AppRoutingModule } from '@app/app-routing.module';
// Need the following to resolve ContentLayoutComponent as it is used in app routing
import { ContentLayoutComponent } from '@app/layouts/content-layout/content-layout.component';
// Need the following to resolve AuthLayoutComponent as it is used in app routing
import { AuthLayoutComponent } from '@app/layouts/auth-layout/auth-layout.component';
// Need the following to resolve "can't bind to 'icon' since it is unknown property of 'fa-icon'"
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
////////////////////////////////////////////////////////////////////////////////

// Need the following to resolve an error with unknown formGroup attribute 
import { ReactiveFormsModule, FormsModule  } from '@angular/forms';
import { validUser } from '@app/mocks';
import { AuthService, User } from '@app/core';
import { of } from 'rxjs';
import { Location } from "@angular/common";
import { appRouteConfig } from '@app/app-routing-config';
import { RouterTestingModule, SpyNgModuleFactoryLoader  } from "@angular/router/testing";
import { NgModuleFactoryLoader } from '@angular/core';
import { AuthModule } from '@app/modules/auth/auth.module';

// // Router Stub class to be used to test component function that uses Routes 
// class RouterStub {
//   navigate(url: string[]) {
//     return url;
//   }
// }

describe('LoginComponent', () => {
  let component: LoginComponent;
  let location: Location;
  let router: Router;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginComponent, AuthLayoutComponent, ContentLayoutComponent],
      imports: [ ReactiveFormsModule, SharedModule, RouterTestingModule.withRoutes(appRouteConfig),
                 AppRoutingModule, FontAwesomeModule, FormsModule],
      providers: [ { provide: NgModuleFactoryLoader, useClass: SpyNgModuleFactoryLoader } ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    let injector = getTestBed();
    router = injector.get(Router);
    location = injector.get(Location);
  });

  // create reusable function for a dry spec.
  function updateForm(userEmail, userPassword) {
    component.loginForm.controls['username'].setValue(userEmail);
    component.loginForm.controls['password'].setValue(userPassword);
    // need to detectChanges and wait for async operations are all complete just in case
    fixture.detectChanges();
    return fixture.whenStable();
  }

  it('should create a LoginComponent', () => {
    expect(component).toBeTruthy();
  });

  it('should create two inputs with username and password fields and the submit button', () => {
    const compiled = fixture.debugElement.nativeElement;
    const inputs = compiled.querySelectorAll('input');
    // there should be at least one input
    expect(inputs).not.toBeNull();
    // inputs should be an array
    expect(inputs.length).toBeTruthy();
    // User name and password inputs should have been created
    expect(inputs.length).toEqual(2);
    for(let input of inputs) {
      expect(input.getAttribute('formControlName')).toMatch('(username|password)');
    }    
  });

  it('should create a submit button', () => {
    const compiled = fixture.debugElement.nativeElement;
    const button = compiled.querySelector('button[type="submit"]');
    // there should be a submit button
    expect(button).not.toBeNull();
  });

  // fakeAsync is important to ensure the following test works as binding occurs asynchronously
  it('should mark the login form valid if both the username & password fields are filled in', fakeAsync(() => {
    updateForm(validUser.username, validUser.password)
    .then( () => {
      // expect(component.loginForm.value).toEqual(validUser);
      expect(component.loginForm.valid).toBeTruthy();
    });
  }));

  it('should mark the login form invalid if either username or password field is empty', fakeAsync(() => {
    updateForm('Choij', '')
    .then( () => {
      expect(component.loginForm.valid).toBeFalsy();
    });
    
    updateForm('', 'password')
    .then( () => {
      expect(component.loginForm.valid).toBeFalsy();
    });

    updateForm('', '')
    .then( () => {
      expect(component.loginForm.valid).toBeFalsy();
    });
  }));

  it('should enable the submit button when both username and password fields are filled in', fakeAsync(() => {
    updateForm(validUser.username, validUser.password)
      .then( data => {    
        const compiled = fixture.debugElement.nativeElement;
        // select the submit button
        const button = compiled.querySelector("button[type='submit']");
        expect(button.disabled).toBeFalsy();
      });
  }));

  it('should disable the submit button when either username or password fields is empty', fakeAsync(() => {
    updateForm('choij', '')
      .then( data => {
        const compiled = fixture.debugElement.nativeElement;
        // select the submit button
        const button = compiled.querySelector("button[type='submit']");
        // disable attribute should exist
        expect(button.disabled).toBeTruthy();
      });
  }));

  // simple version that tests if navigate method is called from login method alogn with the target routing url
  // This might simply unit testing but this requires the unit test to know the actual implementation of the target method which is not ideal.
  it('should allow a valid user to login', inject([Router], (router: Router) => {
    const spyRouter = spyOn(router, 'navigate');
    const mockAuthSvc = TestBed.get(AuthService);
    // mock user
    const user: User = new User();
    user.username = 'Mathis';
    user.password ='12345';
    user.token = '12345';
    spyOn(mockAuthSvc, 'login').and.returnValue(of(user));
  
    updateForm(validUser.username, validUser.password)
      .then( () => {
        component.login();
        fixture.detectChanges();
        fixture.whenStable()
          .then( () => {
            expect(spyRouter.calls.first().args[0]).toBe(['/dashboard/home']);
          });
      });
  }));
});
