import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivityHomeDashboardComponent } from './activity-home-dashboard.component';

describe('ActivityHomeDashboardComponent', () => {
  let component: ActivityHomeDashboardComponent;
  let fixture: ComponentFixture<ActivityHomeDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ActivityHomeDashboardComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(ActivityHomeDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
