import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Api } from 'src/app/shared/api';

@Injectable({
  providedIn: 'root'
})
export class AddEditFnCaseNoteService {

  constructor(private http: HttpClient) { }

  createCaseNote(caseNote: any) {
    const url = `${Api.CaseNotesUrl}`;
    return this.http.post(url, caseNote);
  }

  updateCaseNote(caseNote: any) {
    const url = `${Api.CaseNotesUrl}`;
    return this.http.put(url, caseNote);
  }
}
