import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Api } from 'src/app/shared/api';
import { FnCaseNotesService } from './fn-case-notes.service';

describe('FnCaseNotesService', () => {
  let service: FnCaseNotesService;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ],
      providers: [ FnCaseNotesService ]
    }).compileComponents();
  });

  beforeEach(() => {
    service = TestBed.inject(FnCaseNotesService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  }); 

  it('should be created', () => {
    expect(service).toBeTruthy();   // Assert
  });

  it('should make a get request to url when getCaseNotesByFNId is called', () => {
    // Arrange
    const fnId = 25;

    // Act
    service.getCaseNotesByFNId(fnId).subscribe();

    // Assert
    const request = httpMock.expectOne({method: 'GET', url: `${Api.FNCaseNotesUrl}/${fnId}`});
    expect(request.request.url).toBe(`${Api.FNCaseNotesUrl}/${fnId}`);
    expect(request.request.method).toBe('GET');
    request.flush(fnId);
  });

  it('should make a delete request to url when deleteCaseNote is called', () => {
    // Arrange
    const caseNoteId = 1;

    // Act
    service.deleteCaseNote(caseNoteId).subscribe();

    // Assert
    const request = httpMock.expectOne({method: 'DELETE', url: `${Api.CaseNotesUrl}/${caseNoteId}`});
    expect(request.request.url).toBe(`${Api.CaseNotesUrl}/${caseNoteId}`);
    expect(request.request.method).toBe('DELETE');
    request.flush(caseNoteId);
  });
});
