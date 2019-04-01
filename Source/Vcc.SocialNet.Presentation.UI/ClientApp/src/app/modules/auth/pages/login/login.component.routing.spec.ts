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
import { User } from '@app/core';
import { AuthService, ILoginContext } from '@app/core/services/auth.service';
import { of } from 'rxjs';
import { Location } from "@angular/common";
import { appRouteConfig } from '@app/app-routing-config';
import { RouterTestingModule, SpyNgModuleFactoryLoader  } from "@angular/router/testing";
import { NgModuleFactoryLoader } from '@angular/core';
import { AuthModule } from '@app/modules/auth/auth.module';
import { calcPossibleSecurityContexts } from '@angular/compiler/src/template_parser/binding_parser';

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
  let mockAuthSvc: AuthService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuthLayoutComponent, ContentLayoutComponent],
      imports: [ ReactiveFormsModule, SharedModule, RouterTestingModule.withRoutes(appRouteConfig),
                 AppRoutingModule, FontAwesomeModule, FormsModule, AuthModule],
      providers: [ 
        { provide: NgModuleFactoryLoader, useClass: SpyNgModuleFactoryLoader }, 
        {provide: AuthService}
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    mockAuthSvc = new AuthService();
    
    // mock user
    const user: User = new User();
    user.username = 'Mathis';
    user.password ='12345';
    user.token = '12345';

    spyOn(mockAuthSvc, 'login').and.returnValue(of(user));

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

  // This is complex unit test that involves the router.
  // Unit test should only focus on testing the functionality of the method without other components that can affect test results.
  // The simpler version of the unit test in login.component.spect.ts does that but it also has an issue 
  // that the unit test is aware of the actual implementation of the target method such as whether it is using navigate or navigateByUrl
  // For now, I am just using the simple version just to proceed with other development
  
  // it('should allow a valid user to login', fakeAsync(inject([AuthService], (mockAuthSvc: AuthService ) => {
  //   const loader = TestBed.get(NgModuleFactoryLoader);
  //   loader.stubbedModules = {'authModule': AuthModule};
  //   router.resetConfig([
  //      {path: 'auth', loadChildren: 'authModule'}
  //   ]);

  //   updateForm(validUser.username, validUser.password)
  //     .then( () => {        
  //       //let subscript = component.login();        
  //       // tick();
  //       // expect(location.path()).toBe('/dashboard/home');
  //       // fixture.detectChanges();
  //       // fixture.whenStable()
  //       //   .then( () => {         
  //       //     expect(location.path()).toBe('/dashboard/home');
  //       //   });
        
  //     });
  // })));
});
