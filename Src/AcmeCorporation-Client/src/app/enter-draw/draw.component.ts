import { Component } from '@angular/core';
import { SerialValidationService } from './services/serialvalidation.service';
import { SerialValidationResponse } from './model/SerialValidationResponse';
import { DrawService } from '../services/draw.service';
import { SubmitDrawRequest } from '../services/submitDrawRequest';

import {Router} from '@angular/router';
import { Title } from '../../../node_modules/@angular/platform-browser';


@Component({
  selector: 'app-draw',
  templateUrl: './draw.component.html',
  styleUrls: ['./draw.component.css']
})
export class DrawComponent {

  serialValidationResult: SerialValidationResponse = {
    isValid: false,
    errorMessage: ''
  };

  drawRequest: SubmitDrawRequest = {
    firstName: '',
    lastName: '',
    emailAdress: '',
    serialNumber: ''
  };

  hasAcceptedTermsOfUse = false;

  constructor(private serialValidationService: SerialValidationService, private drawService: DrawService, private router: Router,
    private title: Title ) {
    this.title.setTitle('Enter the draw!');
    this.router = router;
  }

  declinedTerms() {
    this.router.navigateByUrl('/home');
  }

  acceptedTerms() {
    this.hasAcceptedTermsOfUse = true;
  }

  serialEntered(event: any) {
    const serial = event.target.value;
    if (serial.length < 1) {
      return;
    }

    // add some throttle logic to mitigate some of the serverload

    this.serialValidationService.validateSerialNumber(serial)
      .subscribe(result => {
        this.serialValidationResult = result;
      });
    }

    onSubmit() {

      if(this.serialValidationResult.isValid === false) {
        return;
      }
      

      this.drawService.submitDraw(this.drawRequest)
       .subscribe(response => {
         this.router.navigateByUrl('/receipt');
        });
    }
  }
