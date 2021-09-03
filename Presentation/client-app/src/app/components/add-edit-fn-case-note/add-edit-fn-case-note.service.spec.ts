import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Api } from 'src/app/shared/api';
import { AddEditFnCaseNoteService } from './add-edit-fn-case-note.service';

describe('AddEditFnCaseNoteService', () => {
  let service: AddEditFnCaseNoteService;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ],
      providers: [ AddEditFnCaseNoteService ]
    }).compileComponents();
  });

  beforeEach(() => {
    service = TestBed.inject(AddEditFnCaseNoteService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  }); 

  it('should be created', () => {
    expect(service).toBeTruthy();   // Assert
  });

  it('should make a post request to url when createCaseNote is called', () => {
    // Arrange
    const caseNote: any = {
      title: 'Create Case Note',
      foreignNationalId: 25
    };

    // Act
    service.createCaseNote(caseNote).subscribe(response => {
      expect(response).toEqual(caseNote, 'should return the new case note');
    });

    // Assert
    const request = httpMock.expectOne({method: 'POST', url: `${Api.CaseNotesUrl}`});
    expect(request.request.url).toBe(`${Api.CaseNotesUrl}`);
    expect(request.request.method).toBe('POST');
    expect(request.request.body).toEqual(caseNote);
    request.flush(caseNote);
  });

  it('should make a put request to url when updateCaseNote is called', () => {
    // Arrange
    const caseNote: any = {
      id: 1,
      title: 'Update Case Note',
      foreignNationalId: 25
    };

    // Act
    service.updateCaseNote(caseNote).subscribe(response => {
      expect(response).toEqual(caseNote, 'should return the updated case note');
    });

    // Assert
    const request = httpMock.expectOne({method: 'PUT', url: `${Api.CaseNotesUrl}`});
    expect(request.request.url).toBe(`${Api.CaseNotesUrl}`);
    expect(request.request.method).toBe('PUT');
    expect(request.request.body).toEqual(caseNote);
    request.flush(caseNote);
  });
});
