import { Component } from '@angular/core';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './login.component.html'
})
export class LoginComponent {

  constructor(
    private readonly fb: FormBuilder,
    private readonly authService: AuthService,
    private readonly router: Router
  ) {
  }

  form = this.fb.group({
    email: ['', Validators.required],
    password: ['', Validators.required]
  });

  login(): void {

    if (this.form.invalid) {
      return;
    }

    this.authService
      .login(this.form.getRawValue() as any)
      .subscribe(() =>
      {
        this.router.navigate(
          ['/dashboard']);
      });
  }
}
