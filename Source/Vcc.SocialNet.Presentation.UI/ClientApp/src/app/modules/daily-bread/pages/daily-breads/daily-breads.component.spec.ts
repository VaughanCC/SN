import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DailyBreadsComponent } from './daily-breads.component';

describe('DailyBreadsComponent', () => {
  let component: DailyBreadsComponent;
  let fixture: ComponentFixture<DailyBreadsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DailyBreadsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DailyBreadsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
