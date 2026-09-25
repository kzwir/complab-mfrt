import { Component } from '@angular/core';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import { CommonModule } from '@angular/common';

import { TestService } from '../../core/services/test.service';

@Component({
  selector: 'app-test-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './test-form.component.html'
})
export class TestFormComponent {

  constructor(
    private readonly fb: FormBuilder,
    private readonly service: TestService
  ) {
  }

  form = this.fb.group({
    sampleId: ['', Validators.required],
    testType: ['MFR', Validators.required],
    measurementValue: [0, Validators.required]
  });

  save(): void {

    this.service
      .create(this.form.getRawValue() as any)
      .subscribe();
  }
}
