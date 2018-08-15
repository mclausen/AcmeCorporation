import { Component, OnInit } from '@angular/core';
import {DrawService} from '../services/draw.service';
import { PagedDrawSubmissionsResponse } from '../services/PagedDrawSubmissionsResponse';
import { Title } from '../../../node_modules/@angular/platform-browser';
import { Router } from '../../../node_modules/@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-drawoverview',
  templateUrl: './drawoverview.component.html',
  styleUrls: ['./drawoverview.component.css']
})
export class DrawOverviewComponent implements OnInit {

  listingResponse: PagedDrawSubmissionsResponse;

  constructor(private drawService: DrawService, title: Title, private router: Router, private userService: UserService) {
    title.setTitle('See who entered the draw');
  }

  ngOnInit(): void {

    const accessInfo = this.userService.getAcccessInfo();
    if (accessInfo.isLoggedIn === false) {
      this.router.navigateByUrl('/login');
    }

    this.fetchPage(0);
  }



  selectPage(pageNumber: number) {
    if (pageNumber === this.listingResponse.currentPage) {
      return;
    }

    this.fetchPage(pageNumber);
  }

  next() {
    const pageToFetch = this.listingResponse.currentPage + 1;
    if (pageToFetch > this.listingResponse.numberOfPages) {
      return;
    }

    this.fetchPage(pageToFetch);
  }

  previous() {
    const pageToFetch = this.listingResponse.currentPage - 1;
    if (pageToFetch < 1) {
      return;
    }

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
