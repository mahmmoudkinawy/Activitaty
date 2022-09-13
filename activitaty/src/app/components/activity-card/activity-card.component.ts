import { Component, EventEmitter, Input, Output } from '@angular/core';

import { Activity } from 'src/app/models/activity';

@Component({
  selector: 'app-activity-card',
  templateUrl: './activity-card.component.html',
  styleUrls: ['./activity-card.component.scss'],
})
export class ActivityCardComponent {
  @Output() sendActivityToParent = new EventEmitter<Activity>();
  @Input() activity: Activity | null = null;
  editMode = false;

  formMode(editMode: boolean) {
    this.editMode = editMode;
  }

  getActivity(activity: Activity) {
    this.sendActivityToParent.emit(activity);
  }
}
