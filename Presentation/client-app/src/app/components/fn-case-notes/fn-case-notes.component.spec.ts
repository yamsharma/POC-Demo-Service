import { TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import { FnCaseNotesComponent } from './fn-case-notes.component';
import { FnCaseNotesService } from './fn-case-notes.service';

class MockService {
  getCaseNotesByFNId() {}
  deleteCaseNote() {}
}

class MockActivatedRoute extends ActivatedRoute {
  constructor() {
      super();
      this.params = of({fnId: 25 });
  }
}

describe('FnCaseNotesComponent', () => {
  let component: FnCaseNotesComponent;
  let service: FnCaseNotesService;
  
  beforeEach(async () => {
    TestBed.configureTestingModule({
      providers : [
        FnCaseNotesComponent, 
        { provide : FnCaseNotesService, useClass : MockService },
        { provide : ActivatedRoute, useClass: MockActivatedRoute }
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    component = TestBed.inject(FnCaseNotesComponent);
    service = TestBed.inject(FnCaseNotesService);
  });

  it('should create', () => {
    expect(component).toBeTruthy();   // Assert
  });

  it('should have titleValue empty string after construction', () => {
    expect(component.titleValue).toBe('');    // Assert
  });

  it('should have fnCaseNotes undefined after construction', () => {
    expect(component.fnCaseNotes).toBe(undefined);    // Assert
  });

  it('should have fnId undefined after construction', () => {
    expect(component.fnId).toBe(undefined);   // Assert
  });

  it('should have fnCaseNotes set after Angular calls ngOnInit', () => {
    // Arrange
    spyOn(service, 'getCaseNotesByFNId').withArgs(25).and.returnValue(of([
      {
          id: 1,
          title: "GDPR Consent Notification",
          foreignNationalId: 25
      },
      {
          id: 2,
          title: "Personal Questionnaire Submitted Notification",
          foreignNationalId: 25
      },
      {
          id: 3,
          title: "I-485 Questionnaire Submitted Notification",
          foreignNationalId: 25
      }
    ]));

    // Act
    component.ngOnInit();

    // Assert
    expect(component.fnId).toBe(25);
    expect(service.getCaseNotesByFNId).toHaveBeenCalled();
    expect(component.fnCaseNotes?.length).toBe(3);
  });
  
  it('should have called deleteCaseNote on service after calling deleteCaseNote', () => {
    // Arrange
    spyOn(service, 'deleteCaseNote').withArgs(1).and.returnValue(of({}));

    // Act
    component.deleteCaseNote(1);

    // Assert
    expect(service.deleteCaseNote).toHaveBeenCalled();
  });
});
