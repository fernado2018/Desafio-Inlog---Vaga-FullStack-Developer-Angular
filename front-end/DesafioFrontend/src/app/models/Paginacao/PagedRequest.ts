export interface PagedRequest {
  page?: number;
  pageSize?: number;
  orderDesc?: boolean;
  orderBy?: string;
  filtro?: string;
}
