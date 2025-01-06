export interface HttpResponse<T> {
  value: T;
  statusCode: number;
  contentType: string;
}

