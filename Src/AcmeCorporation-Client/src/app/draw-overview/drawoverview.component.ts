import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-drawoverview',
  templateUrl: './drawoverview.component.html',
  styleUrls: ['./drawoverview.component.css']
})
export class DrawOverviewComponent implements OnInit {
  items: DrawListModel[];
  pagination: PaginationInfo;

  ngOnInit(): void {
  }

  selectPage(pageNumber: number) {
    console.log('selected page: ' + pageNumber );
  }

  next() {
    console.log('clicked next');
  }

  previous() {
    console.log('clicked previous');
  }
}

export class DrawListModel {
  firstName: string;
  lastName: string;
  email: string;
  serial: string;
}

export class PaginationInfo {
  currentPage: number;
  numberOfPages: number;
}
