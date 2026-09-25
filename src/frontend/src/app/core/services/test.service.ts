import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';

import {
  LaboratoryTest,
  CreateTestRequest,
  UpdateTestRequest
} from '../../shared/models/test.model';

@Injectable({
  providedIn: 'root'
})
export class TestService {

  private readonly api =
    `${environment.apiUrl}/tests`;

  constructor(
    private readonly http: HttpClient
  ) {
  }

  getAll(): Observable<LaboratoryTest[]> {
    return this.http.get<LaboratoryTest[]>(
      this.api);
  }

  create(
    request: CreateTestRequest
  ): Observable<string> {
    return this.http.post<string>(
      this.api,
      request);
  }

  update(
    id: string,
    request: UpdateTestRequest
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
