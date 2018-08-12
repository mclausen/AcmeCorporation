import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SerialValidationResponse } from '../model/serialValidationResponse';

@Injectable()
export class SerialValidationService {
  constructor(private http: HttpClient) { }


  validateSerialNumber(serial: string) {

    const url = 'https://localhost:5001/serials/' + serial + '/validate';
    return this.http.get<SerialValidationResponse>(url);
  }
}

