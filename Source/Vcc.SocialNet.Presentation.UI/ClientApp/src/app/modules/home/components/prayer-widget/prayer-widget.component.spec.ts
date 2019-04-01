import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrayerWidgetComponent } from './prayer-widget.component';

describe('PrayerWidgetComponent', () => {
  let component: PrayerWidgetComponent;
  let fixture: ComponentFixture<PrayerWidgetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrayerWidgetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrayerWidgetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
