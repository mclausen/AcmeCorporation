import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SerialValidationResponse } from '../model/SerialValidationResponse';

@Injectable()
export class SerialValidationService {
  constructor(private http: HttpClient) { }


  validateSerialNumber(serial: string) {

    const url = 'http://localhost:5000/serials/' + serial + '/validate';
    return this.http.get<SerialValidationResponse>(url);
  }
}

