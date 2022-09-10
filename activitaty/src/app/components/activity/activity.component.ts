import { Component, Input } from '@angular/core';

import { Activity } from 'src/app/models/activity';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.scss'],
})
export class ActivityComponent {
  @Input() activity: Activity | null = null;
}
