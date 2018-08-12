import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SerialValidationResponse } from '../model/SerialValidationResponse';

@Injectable()
export class SerialValidationService {
  constructor(private http: HttpClient) { }


  validateSerialNumber(serial: string) {

    const url = 'https://localhost:5001/serials/' + serial + '/validate';
    return this.http.get<SerialValidationResponse>(url);
  }
}

