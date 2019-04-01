import { async, ComponentFixture, TestBed } from '@angular/core/testing';

////////////////////////////////////////////////////////////////////////////////
// The folloiwng import modules are needed for most of the unit  tests 
// Need the following to resolve a problem with an error with [Object Object] not found error: usually this refers to the fact that Routing module not imported
import { RouterModule } from '@angular/router';
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


describe('AuthLayoutComponent', () => {
  let component: AuthLayoutComponent;
  let fixture: ComponentFixture<AuthLayoutComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuthLayoutComponent, ContentLayoutComponent],
      imports: [ RouterModule, SharedModule, AppRoutingModule, FontAwesomeModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuthLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should generate a correct banner image URL', () => {
    // for private function or member, use array expression to access it
    const url = component['generateBannerUrl']();
    expect(url).not.toBeNull();
    expect(url.length).toBeGreaterThan(0);
  });
});
