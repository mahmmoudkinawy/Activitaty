import { Component, EventEmitter, Output, Input } from '@angular/core';

import { Activity } from 'src/app/models/activity';

@Component({
  selector: 'app-activity-form',
  templateUrl: './activity-form.component.html',
  styleUrls: ['./activity-form.component.scss'],
})
export class ActivityFormComponent {
  @Output() sendActivityToParent = new EventEmitter<Activity>();
  @Output() formMode = new EventEmitter<boolean>();
  @Input() activity: Activity | null = null;

  formModeUpdate() {
    this.formMode.emit(false);
  }

  onSendActivityToParent() {
    this.sendActivityToParent.emit(this.activity!);
  }
}
