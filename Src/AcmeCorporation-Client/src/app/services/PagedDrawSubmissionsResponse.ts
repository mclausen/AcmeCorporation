import { DrawSubmissionListingsDto } from './DrawSubmissionListingsDto';

export class PagedDrawSubmissionsResponse {
  currentPage: number;
  numberOfPages: number;
  submissions: DrawSubmissionListingsDto[];
}
