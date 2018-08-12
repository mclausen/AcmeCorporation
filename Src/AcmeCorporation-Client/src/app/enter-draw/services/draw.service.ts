import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders } from '@angular/common/http';
import { SubmitDrawRequest } from '../model/submitDrawRequest';

@Injectable()
export class DrawService {
  constructor(private http: HttpClient) { }


  SubmitDraw(drawRequest: SubmitDrawRequest) {


    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };

    const obj = {
      FirstName: drawRequest.firstName,
      LastName: drawRequest.lastName,
      SerialNumber: drawRequest.serialNumber,
      EmailAddress: drawRequest.emailAdress
    };

    const url = 'https://localhost:5001/submissions';
    return this.http.post(url, JSON.stringify(obj) , httpOptions);
  }
}

