import { Component, ViewChild } from '@angular/core';
import { SerialValidationService } from './services/serialvalidation.service';
import { SerialValidationResponse } from './model/SerialValidationResponse';
import { DrawService } from './services/draw.service';
import { SubmitDrawRequest } from './model/submitDrawRequest';
import { NgForm } from '../../../node_modules/@angular/forms';
import { detectChanges } from '../../../node_modules/@angular/core/src/render3';



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

  constructor(private serialValidationService: SerialValidationService, private drawService: DrawService) {
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
