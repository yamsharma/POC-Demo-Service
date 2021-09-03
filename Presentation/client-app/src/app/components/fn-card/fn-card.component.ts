import { Component, Input, OnInit } from '@angular/core';
import { FnInfo } from '../../shared/models/fn-info.model';
import { FnCardService } from './fn-card.service';

@Component({
  selector: 'app-fn-card',
  templateUrl: './fn-card.component.html',
  styleUrls: ['./fn-card.component.css'],
})
export class FnCardComponent implements OnInit {
  fnInfo?: FnInfo;
  @Input() loadCaseNotesComponent = false;

  constructor(private service: FnCardService) {}

  ngOnInit() {
    this.getFnInfo();
  }

  private getFnInfo() {
    this.service.getFNInfo().subscribe((response) => {
      this.fnInfo = response;
    });
  }

  displayCaseNotesComponent() {
    this.loadCaseNotesComponent = true;
  }
}
