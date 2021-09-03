import { TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { FnCardComponent } from './fn-card.component';
import { FnCardService } from './fn-card.service';

class MockService {
  getFNInfo() {}
}

describe('FnCardComponent', () => {
  let component: FnCardComponent;
  let service: FnCardService;
  
  beforeEach(async () => {
    TestBed.configureTestingModule({
      providers : [
        FnCardComponent, 
        { provide : FnCardService, useClass : MockService }
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    component = TestBed.inject(FnCardComponent);
    service = TestBed.inject(FnCardService);
  });

  it('loadCaseNotesComponent should be false after construction', () => {
    expect(component.loadCaseNotesComponent).toBeFalse();   // Assert
  });

  it('fnInfo should be undefined after construction', () => {
    expect(component.fnInfo).toBe(undefined);   // Assert
  });

  it('displayCaseNotesComponent should set loadCaseNotesComponent to true', () => {
    component.displayCaseNotesComponent();    // Act

    expect(component.loadCaseNotesComponent).toBeTrue();    // Assert
  });
  
  it('should have fnInfo after Angular calls ngOnInit', () => {
    // Arrange
    spyOn(service, 'getFNInfo').and.returnValue(of({
      id: 25,
      firstName: "Michael",
      lastName: "Scofield"
    }));

    // Act
    component.ngOnInit();

    // Assert
    expect(component.fnInfo?.id).toBe(25);
  });
});
