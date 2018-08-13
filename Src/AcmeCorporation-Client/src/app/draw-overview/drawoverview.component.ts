import { Component, OnInit } from '@angular/core';
import {DrawService} from '../services/draw.service';
import { PagedDrawSubmissionsResponse } from '../services/PagedDrawSubmissionsResponse';
import { DrawSubmissionListingsDto } from '../services/DrawSubmissionlistingsDto';

@Component({
  selector: 'app-drawoverview',
  templateUrl: './drawoverview.component.html',
  styleUrls: ['./drawoverview.component.css']
})
export class DrawOverviewComponent implements OnInit {

  listingResponse: PagedDrawSubmissionsResponse;

  constructor(private drawService: DrawService) {
  }

  ngOnInit(): void {
    this.fetchPage(0);
  }



  selectPage(pageNumber: number) {
    if(pageNumber === this.listingResponse.currentPage) {
      return;
    }

    this.fetchPage(pageNumber);
  }

  next() {
    const pageToFetch = this.listingResponse.currentPage + 1;
    this.fetchPage(pageToFetch);
  }

  previous() {
    const pageToFetch = this.listingResponse.currentPage - 1;
    this.fetchPage(pageToFetch);
  }

  fetchPage(pageNumber: number) {
    this.drawService.getDrawSubmissions(pageNumber)
      .subscribe(response => this.listingResponse = response);
  }

  totalNumberOfPagesToArray(numberOfPages: number): any[] {
    return Array(numberOfPages);
  }
}
