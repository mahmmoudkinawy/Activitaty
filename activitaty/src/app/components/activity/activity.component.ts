import { Component, EventEmitter, Input, Output } from '@angular/core';

import { Activity } from 'src/app/models/activity';

@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.scss'],
})
export class ActivityComponent {
  @Output() sendActivityToParent = new EventEmitter<Activity>();
  @Output() sendActivityIdToParent = new EventEmitter<string>();
  @Input() activity: Activity | null = null;

  onSendActivityToParent() {
    this.sendActivityToParent.emit(this.activity!);
  }

  onSendActivityIdToParent() {
    this.sendActivityIdToParent.emit(this.activity?.id);
  }
}
