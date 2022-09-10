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
}
