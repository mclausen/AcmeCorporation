import { DrawSubmissionListingsDto } from './drawSubmissionlistingsDto';

export class PagedDrawSubmissionsResponse {
  currentPage: number;
  numberOfPages: number;
  submissions: DrawSubmissionListingsDto[];
}
