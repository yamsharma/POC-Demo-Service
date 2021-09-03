import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CaseNote } from 'src/app/shared/models/case-notes.model';
import { AddEditFnCaseNoteService } from './add-edit-fn-case-note.service';

@Component({
  selector: 'app-add-edit-fn-case-note',
  templateUrl: './add-edit-fn-case-note.component.html',
  styleUrls: ['./add-edit-fn-case-note.component.css'],
})
export class AddEditFnCaseNoteComponent implements OnInit {
  caseNoteTitle?: string;
  caseNoteId?: number;
  fnId?: number;

  constructor(private route: ActivatedRoute, private service: AddEditFnCaseNoteService, private router: Router) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      let fnid = params.get('fnId');
      let id = params.get('id');
      let title = params.get('title');

      if (id !== null) {
        this.caseNoteId = +id;
      }

      if (title !== null) {
        this.caseNoteTitle = title;
      }

      if (fnid !== null) {
        this.fnId = +fnid;
      }
    });
  }

  onSubmit() {
    if (this.caseNoteId) {
      this.editCaseNote();
    } else {
      this.addCaseNote();
    }
  }

  private addCaseNote() {
    const caseNote: any = {
      title: this.caseNoteTitle!,
      foreignNationalId: this.fnId!
    };
    this.service.createCaseNote(caseNote).subscribe(() => {
      this.navigateToHome();
    });
  }

  private editCaseNote() {
    if (this.caseNoteId) {
      const caseNote: CaseNote = {
        id: this.caseNoteId,
        title: this.caseNoteTitle!,
        foreignNationalId: this.fnId!
      };
      this.service.updateCaseNote(caseNote).subscribe(() => {
        this.navigateToHome();
      });
    }
  }

  private navigateToHome() {
    this.router.navigate(['/Home', true, this.fnId]);
  }
}
