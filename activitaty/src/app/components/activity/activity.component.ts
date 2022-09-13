import { Component, EventEmitter, Input, Output } from '@angular/core';

import { Activity } from 'src/app/models/activity';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.scss'],
})
export class ActivityComponent {
  @Output() activityToParent = new EventEmitter<Activity>();
  @Input() activity: Activity | null = null;

  onSendActivityToParent() {
    this.activityToParent.emit(this.activity!);
  }
}
