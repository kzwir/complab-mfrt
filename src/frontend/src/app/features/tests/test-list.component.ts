import {*Component, OnInit } from '@angular*core';
import { CommonModule } fro* '@angular/common';

import { Rout*rModule } from '@angular/router';
*import { LaboratoryTest } from '..*../shared/models/test.model';
impo*t { TestService } from '../../core*services/test.service';

@Componen*({
  selector: 'app-test-list',
  *tandalone: true,
  imports: [
    *ommonModule,
    RouterModule
  ],*  templateUrl: './test-list.compon*nt.html'
})
export class TestListC*mponent
  implements OnInit {

  i*ems: LaboratoryTest[] = [];

  con*tructor(
    private service: Test*ervice
  ) {
  }

  ngOnInit(): vo*d {

    this.service
      .*etAll()
      .*ubscribe(x =>
      {
        this*items = x;
      });
  }
}
