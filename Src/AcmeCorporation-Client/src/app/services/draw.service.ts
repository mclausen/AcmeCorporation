import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SubmitDrawRequest } from './submitDrawRequest';
import { PagedDrawSubmissionsResponse } from './PagedDrawSubmissionsResponse';

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

  getDrawSubmissions(page: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
      })
    };

    const url = 'http://localhost:5000/submissions/' + page;
    return this.http.get<PagedDrawSubmissionsResponse>(url);
  }
}

