import { DrawSubmissionListingsDto } from './DrawSubmissionlistingsDto';

export class PagedDrawSubmissionsResponse {
  currentPage: number;
  numberOfPages: number;
  submissions: DrawSubmissionListingsDto[];
}
