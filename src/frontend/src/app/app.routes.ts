import { Routes } from '@angular/router';

import { authGuard } from './core/guards/auth.guard';

import { LoginComponent } from './features/auth/login.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';

import { MixtureListComponent } from './features/mixtures/mixture-list.component';
import { MixtureFormComponent } from './features/mixtures/mixture-form.component';
import { MixtureEditComponent } from './features/mixtures/mixture-edit.component';

import { SampleListComponent } from './features/samples/sample-list.component';
import { SampleFormComponent } from './features/samples/sample-form.component';
import { SampleEditComponent } from './features/samples/sample-edit.component';

import { TestListComponent } from './features/tests/test-list.component';
import { TestFormComponent } from './features/tests/test-form.component';
import { TestEditComponent } from './features/tests/test-edit.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },

  {
    path: 'login',
    component: LoginComponent
  },

  {
    path: 'dashboard',
    component: DashboardComponent,
    canActivate: [authGuard]
  },

  {
    path: 'mixtures',
    component: MixtureListComponent,
    canActivate: [authGuard]
  },

  {
    path: 'mixtures/new',
    component: MixtureFormComponent,
    canActivate: [authGuard]
  },

  {
    path: 'mixtures/:id/edit',
    component: MixtureEditComponent,
    canActivate: [authGuard]
  },

  {
    path: 'samples',
    component: SampleListComponent,
    canActivate: [authGuard]
  },

  {
    path: 'samples/new',
    component: SampleFormComponent,
    canActivate: [authGuard]
  },

  {
    path: 'samples/:id/edit',
    component: SampleEditComponent,
    canActivate: [authGuard]
  },

  {
    path: 'tests',
    component: TestListComponent,
    canActivate: [authGuard]
  },

  {
    path: 'tests/new',
    component: TestFormComponent,
    canActivate: [authGuard]
  },

  {
    path: 'tests/:id/edit',
    component: TestEditComponent,
    canActivate: [authGuard]
  }
];
