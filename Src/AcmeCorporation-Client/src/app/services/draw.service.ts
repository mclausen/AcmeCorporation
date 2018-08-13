import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SubmitDrawRequest } from './submitDrawRequest';
import { PagedDrawSubmissionsResponse } from './PagedDrawSubmissionsResponse';
import { environment } from '../../environments/environment';

@Injectable()
export class DrawService {
  constructor(private http: HttpClient) { }


  submitDraw(drawRequest: SubmitDrawRequest) {


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

    const url = environment.endpointUrl + '/submissions';
    return this.http.post(url, JSON.stringify(obj) , httpOptions);
  }

  getDrawSubmissions(page: number) {
    const url = environment.endpointUrl + '/submissions/' + page;
    return this.http.get<PagedDrawSubmissionsResponse>(url);
  }
}

