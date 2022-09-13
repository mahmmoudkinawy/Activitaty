import { Component, Input } from '@angular/core';

import { Activity } from 'src/app/models/activity';

@Component({
  selector: 'app-activity-card',
  templateUrl: './activity-card.component.html',
  styleUrls: ['./activity-card.component.scss'],
})
export class ActivityCardComponent {
  editMode = false;
  @Input() activity: Activity | null = null;

  formMode(editMode: boolean) {
    this.editMode = editMode;
  }
}
