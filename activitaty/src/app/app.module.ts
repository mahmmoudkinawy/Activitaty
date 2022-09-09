import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PrimengModule } from './shared/primeng.module';
import { HeaderComponent } from './components/header/header.component';
import { ActivitiesListComponent } from './components/activities-list/activities-list.component';

@NgModule({
  declarations: [AppComponent, HeaderComponent, ActivitiesListComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PrimengModule,
    HttpClientModule,
    BrowserAnimationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
