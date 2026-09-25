import { Component } from '@angular/core';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import { CommonModule } from '@angular/common';

import { SampleService } from '../../core/services/sample.service';

@Component({
  selector: 'app-sample-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './sample-form.component.html'
})
export class SampleFormComponent {

  constructor(
    private readonly fb: FormBuilder,
    private readonly service: SampleService
  ) {
  }

  form = this.fb.group({
    mixtureId: ['', Validators.required],
    sampleNumber: ['', Validators.required],
    productionDate: ['', Validators.required]
  });

  save(): void {

    this.service
      .create(this.form.getRawValue() as any)
      .subscribe();
  }
}
