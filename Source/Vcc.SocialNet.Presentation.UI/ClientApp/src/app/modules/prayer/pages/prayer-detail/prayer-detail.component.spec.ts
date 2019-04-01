import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrayerDetailComponent } from './prayer-detail.component';

describe('PrayerDetailComponent', () => {
  let component: PrayerDetailComponent;
  let fixture: ComponentFixture<PrayerDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrayerDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrayerDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
