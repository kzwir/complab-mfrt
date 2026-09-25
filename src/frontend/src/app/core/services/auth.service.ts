import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

import { environment } from '../../../environments/environment';
import {
  LoginRequest,
  LoginResponse
} from '../../shared/models/login.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private readonly api =
    `${environment.apiUrl}/auth`;

  constructor(
    private readonly http: HttpClient
  ) {
  }

  login(
    request: LoginRequest
  ): Observable<LoginResponse> {

    return this.http
      .post<LoginResponse>(
        `${this.api}/login`,
        request)
      .pipe(
        tap(response =>
          localStorage.setItem(
            'jwt',
            response.token))
      );
  }

  logout(): void {
    localStorage.removeItem('jwt');
  }

  getToken(): string | null {
    return localStorage.getItem('jwt');
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }
}
