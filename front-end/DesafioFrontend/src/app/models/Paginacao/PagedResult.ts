export interface PagedResult<T = any> {
  currentPage?: number;
  pageCount?: number;
  pageSize?: number;
  rowCount: number;
  results: T[];
}
