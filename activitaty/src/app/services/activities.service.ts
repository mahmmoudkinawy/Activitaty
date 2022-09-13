import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { environment } from 'src/environments/environment';
import { Activity } from '../models/activity';

@Injectable({
  providedIn: 'root',
})
export class ActivitiesService {
  constructor(private http: HttpClient) {}

  getActivities() {
    return this.http.get<Activity[]>(`${environment.apiUrl}/activities`);
  }

  getActivity(id: string) {
    return this.http.get<Activity>(`${environment.apiUrl}/activities/${id}`);
  }

  updateActivity(id: string, activity: Activity) {
    return this.http.put(`${environment.apiUrl}/activities/${id}`, activity);
  }

  deleteActivity(id: string) {
    return this.http.delete(`${environment.apiUrl}/activities/${id}`);
  }
}
