import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Api } from 'src/app/shared/api';
import { CaseNote } from 'src/app/shared/models/case-notes.model';

@Injectable({
  providedIn: 'root',
})
export class FnCaseNotesService {
  constructor(private http: HttpClient) {}

  getCaseNotesByFNId(fnId: number) {
    const url = `${Api.FNCaseNotesUrl}/${fnId}`;
    return this.http.get<CaseNote[]>(url);
  }

  deleteCaseNote(id: number) {
    const url = `${Api.CaseNotesUrl}/${id}`;
    return this.http.delete(url);
  }
}
