import { TestBed } from '@angular/core/testing';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { AddEditFnCaseNoteComponent } from './add-edit-fn-case-note.component';
import { AddEditFnCaseNoteService } from './add-edit-fn-case-note.service';

class MockService {
  createCaseNote() {}
  updateCaseNote() {}
}

class MockRouter {
  navigate() {}
}

class MockActivatedRoute extends ActivatedRoute {
  constructor() {
      super();
      this.params = of({id: 1, fnId: 25, title: 'Test title' });
  }
}

describe('AddEditFnCaseNoteComponent', () => {
  let component: AddEditFnCaseNoteComponent;
  let service: AddEditFnCaseNoteService;
  let router: Router;
  
  beforeEach(async () => {    
    await TestBed.configureTestingModule({
      declarations: [  ],
      providers : [
        AddEditFnCaseNoteComponent,
        { provide : AddEditFnCaseNoteService, useClass : MockService },
        { provide : ActivatedRoute, useClass : MockActivatedRoute },
        { provide : Router, useClass : MockRouter }
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    component = TestBed.inject(AddEditFnCaseNoteComponent);
    service = TestBed.inject(AddEditFnCaseNoteService);
    router = TestBed.inject(Router);
  });

  it('should have caseNoteTitle undefined after construction', () => {
    expect(component.caseNoteTitle).toBe(undefined);    // Assert
  });

  it('should have caseNoteId undefined after construction', () => {
    expect(component.caseNoteId).toBe(undefined);   // Assert
  });

  it('should have fnId undefined after construction', () => {
    expect(component.fnId).toBe(undefined);   // Assert
  });

  it('should have values set after Angular calls ngOnInit', () => {
    // Act
    component.ngOnInit();

    // Assert
    expect(component.fnId).toBe(25);
    expect(component.caseNoteId).toBe(1);
    expect(component.caseNoteTitle).toBe('Test title');
  });

  it('should call createCaseNote on service after submit if caseNoteId is undefined', () => {
    // Arrange
    spyOn(service, 'createCaseNote').and.returnValue(of({}));
    spyOn(router, 'navigate');

    // Act
    component.onSubmit();

    // Assert
    expect(service.createCaseNote).toHaveBeenCalled();
    expect(router.navigate).toHaveBeenCalled();
  });

  it('should call updateCaseNote on service after submit if caseNoteId is present', () => {
    // Arrange
    component.caseNoteId = 1;
    spyOn(service, 'updateCaseNote').and.returnValue(of({}));
    spyOn(router, 'navigate');

    // Act
    component.onSubmit();

    // Assert
    expect(service.updateCaseNote).toHaveBeenCalled();
    expect(router.navigate).toHaveBeenCalled();
  });
});
