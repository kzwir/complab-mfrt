import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardService } from '../../core/services/dashboard.service';
import { Dashboard } from '../../shared/models/dashboard.model';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent
  implements OnInit {

  data?: Dashboard;

  constructor(
    private readonly service: DashboardService
  ) {
  }

  ngOnInit(): void {

    this.service
      .getDashboard()
      .subscribe(x => this.data = x);
  }
}
