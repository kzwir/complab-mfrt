import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';

import {
  Mixture,
  CreateMixtureRequest,
  UpdateMixtureRequest
} from '../../shared/models/mixture.model';

@Injectable({
  providedIn: 'root'
})
export class MixtureService {

  private readonly api =
    `${environment.apiUrl}/mixtures`;

  constructor(
    private readonly http: HttpClient
  ) {
  }

  getAll(): Observable<Mixture[]> {
    return this.http.get<Mixture[]>(this.api);
  }

  get(id: string): Observable<Mixture> {
    return this.http.get<Mixture>(
      `${this.api}/${id}`);
  }

  create(
    request: CreateMixtureRequest
  ): Observable<string> {
    return this.http.post<string>(
      this.api,
      request);
  }

  update(
    id: string,
    request: UpdateMixtureRequest
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
