import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-activity-form',
  templateUrl: './activity-form.component.html',
  styleUrls: ['./activity-form.component.scss'],
})
export class ActivityFormComponent {
  @Output() formMode = new EventEmitter<boolean>();

  formModeUpdate() {
    this.formMode.emit(false);
  }
}
