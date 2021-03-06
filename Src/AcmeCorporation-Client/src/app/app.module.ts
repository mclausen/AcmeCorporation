import { BrowserModule, Title } from '@angular/platform-browser';
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
import { DrawReceiptComponent } from './draw-receipt/draw-receipt.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { UserService } from './services/user.service';
import { LoginPageComponent } from './login-page/login-page.component';
@NgModule({
  declarations: [
    AppComponent,
    DrawComponent,
    DrawOverviewComponent,
    LandingPageComponent,
    DrawReceiptComponent,
    LoginPageComponent,
    NotFoundComponent,

  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [SerialValidationService, DrawService, Title, UserService],
  bootstrap: [AppComponent],
})
export class AppModule { }
