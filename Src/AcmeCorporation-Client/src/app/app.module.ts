import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { DrawComponent } from './enter-draw/draw.component';
import { DrawOverviewComponent } from './draw-overview/drawoverview.component';

import { HttpClientModule } from '@angular/common/http';
import { SerialValidationService } from './enter-draw/services/serialvalidation.service';
import { DrawService } from './services/draw.service';

import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { LandingPageComponent } from './landing-page/landing-page.component';
@NgModule({
  declarations: [
    AppComponent,
    DrawComponent,
    DrawOverviewComponent,
    LandingPageComponent,

  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [SerialValidationService, DrawService],
  bootstrap: [AppComponent],
})
export class AppModule { }
