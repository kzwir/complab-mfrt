import { Component } from '@angular/core';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import { CommonModule } from '@angular/common';

import { MixtureService } from '../../core/services/mixture.service';

@Component({
  standalone: true,
  selector: 'app-mixture-form',
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './mixture-form.component.html'
})
export class MixtureFormComponent {

  constructor(
    private readonly fb: FormBuilder,
    private readonly service: MixtureService
  ) {
  }

  form = this.fb.group({
    code: ['', Validators.required],
    polymerPercent: [0, Validators.required],
    quartzitePercent: [0, Validators.required]
  });

  save(): void {

    if (this.form.invalid) {
      return;
    }

    this.service
      .create(this.form.getRawValue() as any)
      .subscribe();
  }
}
