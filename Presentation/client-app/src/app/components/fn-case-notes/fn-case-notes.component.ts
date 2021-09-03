import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CaseNote } from 'src/app/shared/models/case-notes.model';
import { FnCaseNotesService } from './fn-case-notes.service';

@Component({
  selector: 'app-fn-case-notes',
  templateUrl: './fn-case-notes.component.html',
  styleUrls: ['./fn-case-notes.component.css'],
})
export class FnCaseNotesComponent implements OnInit {
  @Input() fnId?: number;
  fnCaseNotes?: CaseNote[];
  titleValue = '';

  constructor(private service: FnCaseNotesService, private route: ActivatedRoute) {}

  ngOnInit() {
    if (this.fnId === null || this.fnId === undefined) {
      this.getRouteParams();
    } else {
      this.getCaseNotes();
    }
  }

  private getRouteParams() {
    this.route.paramMap.subscribe(params => {
      let fnid = params.get('fnId');

      if (fnid !== null) {
        this.fnId = +fnid;
      }

      this.getCaseNotes();
    });
  }

  private getCaseNotes() {
    if (this.fnId) {
      this.getCaseNotesByFNId(this.fnId);
    }
  }

  private getCaseNotesByFNId(fnId: number) {
    this.service.getCaseNotesByFNId(fnId).subscribe((response) => {
      this.fnCaseNotes = response;
    });
  }

  deleteCaseNote(id: number) {
    this.service.deleteCaseNote(id).subscribe(() => {
      if (this.fnId) {
        this.getCaseNotesByFNId(this.fnId);
      }
    });
  }
}
