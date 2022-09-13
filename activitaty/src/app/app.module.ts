import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PrimengModule } from './shared/primeng.module';

import { HeaderComponent } from './components/header/header.component';
import { ActivityComponent } from './components/activity/activity.component';
import { ActivityCardComponent } from './components/activity-card/activity-card.component';
import { ActivityHomeDashboardComponent } from './components/activity-home-dashboard/activity-home-dashboard.component';
import { ActivityFormComponent } from './forms/activity-form/activity-form.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ActivityHomeDashboardComponent,
    ActivityComponent,
    ActivityCardComponent,
    ActivityFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    PrimengModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
