import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TodaysBreadComponent } from './todays-bread.component';

describe('TodaysBreadComponent', () => {
  let component: TodaysBreadComponent;
  let fixture: ComponentFixture<TodaysBreadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TodaysBreadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TodaysBreadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
