import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyBreadDetailComponent } from './daily-bread-detail.component';

describe('DailyBreadDetailComponent', () => {
  let component: DailyBreadDetailComponent;
  let fixture: ComponentFixture<DailyBreadDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DailyBreadDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DailyBreadDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
