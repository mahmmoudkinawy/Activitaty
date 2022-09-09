import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';

import { Activity } from 'src/app/models/activity';
import { ActivitiesService } from 'src/app/services/activities.service';

@Component({
  selector: 'app-activities-list',
  templateUrl: './activities-list.component.html',
  styleUrls: ['./activities-list.component.scss'],
})
export class ActivitiesListComponent implements OnInit, OnDestroy {
  private readonly dispose$ = new Subject();
  activities: Activity[] = [];

  constructor(private activitiesService: ActivitiesService) {}

  ngOnInit(): void {
    this.loadActivities();
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
