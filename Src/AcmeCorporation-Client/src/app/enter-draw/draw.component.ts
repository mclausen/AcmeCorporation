import { Component } from '@angular/core';
import { SerialValidationService } from './services/serialvalidation.service';
import { SerialValidationResponse } from './model/serialValidationResponse';
import { DrawService } from './services/draw.service';
import { SubmitDrawRequest } from './model/submitDrawRequest';

import {Router} from '@angular/router';


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

  constructor(private serialValidationService: SerialValidationService, private drawService: DrawService, private router: Router) {
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

    this.serialValidationService.validateSerialNumber(serial)
      .subscribe(result => {
        this.serialValidationResult = result;
        console.log(this.serialValidationResult);
      });
    }

    onSubmit() {
      //alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.drawRequest));
      this.drawService.SubmitDraw(this.drawRequest)
       .subscribe(response => {
          console.log(response);
        });
    }
  }
