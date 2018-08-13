import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SerialValidationResponse } from '../model/SerialValidationResponse';
import { environment } from '../../../environments/environment';

@Injectable()
export class SerialValidationService {
  constructor(private http: HttpClient) { }


  validateSerialNumber(serial: string) {
    const url = environment.endpointUrl + '/serials/' + serial + '/validate';
    return this.http.get<SerialValidationResponse>(url);
  }
}

