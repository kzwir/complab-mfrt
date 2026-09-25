import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';

import {
  Sample,
  CreateSampleRequest,
  UpdateSampleRequest
} from '../../shared/models/sample.model';

@Injectable({
  providedIn: 'root'
})
export class SampleService {

  private readonly api =
    `${environment.apiUrl}/samples`;

  constructor(
    private readonly http: HttpClient
  ) {
  }

  getAll(): Observable<Sample[]> {
    return this.http.get<Sample[]>(this.api);
  }

  create(
    request: CreateSampleRequest
  ): Observable<string> {
    return this.http.post<string>(
      this.api,
      request);
  }

  update(
    id: string,
    request: UpdateSampleRequest
  ): Observable<void> {
    return this.http.put<void>(
      `${this.api}/${id}`,
      request);
  }

  delete(
    id: string
  ): Observable<void> {
    return this.http.delete<void>(
      `${this.api}/${id}`);
  }
}
