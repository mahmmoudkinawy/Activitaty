import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  activities: Array<any> = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadActivities().subscribe(
      (response: any) => (this.activities = response)
    );
  }

  loadActivities() {
    return this.http.get('http://localhost:5000/api/activities');
  }
}
