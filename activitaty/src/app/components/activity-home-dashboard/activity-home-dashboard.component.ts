import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';

import { Activity } from 'src/app/models/activity';
import { ActivitiesService } from 'src/app/services/activities.service';

@Component({
  selector: 'app-activity-home-dashboard',
  templateUrl: './activity-home-dashboard.component.html',
  styleUrls: ['./activity-home-dashboard.component.scss'],
})
export class ActivityHomeDashboardComponent implements OnInit, OnDestroy {
  private readonly dispose$ = new Subject();
  activities: Activity[] = [];
  activity: Activity | null = null;

  constructor(private activitiesService: ActivitiesService) {}

  ngOnInit(): void {
    this.loadActivities();
  }

  getActivity(activity: Activity) {
    this.activitiesService
      .getActivity(activity.id)
      .pipe(takeUntil(this.dispose$))
      .subscribe((activity) => (this.activity = activity));
  }

  updateActivity(activity: Activity) {
    this.activitiesService
      .updateActivity(activity.id, activity)
      .pipe(takeUntil(this.dispose$))
      .subscribe(() => this.loadActivities());
  }

  deleteActivity(id: string) {
    this.activitiesService
      .deleteActivity(id)
      .pipe(takeUntil(this.dispose$))
      .subscribe(() => this.loadActivities());
  }

  private loadActivities() {
    this.activitiesService
      .getActivities()
      .pipe(takeUntil(this.dispose$))
      .subscribe((activities) => (this.activities = activities));
  }

  ngOnDestroy(): void {
    this.dispose$.next(null);
    this.dispose$.complete();
  }
}
