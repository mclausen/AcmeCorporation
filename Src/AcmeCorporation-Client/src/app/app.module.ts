import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { DrawComponent } from './enter-draw/draw.component';

import { HttpClientModule } from '@angular/common/http';
import { SerialValidationService } from './enter-draw/services/serialvalidation.service';
import { DrawService } from './enter-draw/services/draw.service';

import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    DrawComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [SerialValidationService, DrawService],
  bootstrap: [AppComponent]
})
export class AppModule { }
