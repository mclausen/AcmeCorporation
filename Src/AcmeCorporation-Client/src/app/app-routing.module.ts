import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { DrawOverviewComponent } from './draw-overview/drawoverview.component';
import { DrawComponent } from './enter-draw/draw.component';
import { DrawReceiptComponent } from './draw-receipt/draw-receipt.component';
import { NotFoundComponent } from './not-found/not-found.component';


const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: LandingPageComponent },
  { path: 'draw', component: DrawComponent },
  { path: 'report', component: DrawOverviewComponent },
  { path: 'receipt', component: DrawReceiptComponent },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {}
