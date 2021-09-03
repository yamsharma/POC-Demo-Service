import { TestBed } from "@angular/core/testing";
import { ActivatedRoute } from "@angular/router";
import { of } from "rxjs";
import { HomeComponent } from "./home.component";

class MockActivatedRoute extends ActivatedRoute {
  constructor() {
      super();
      this.params = of({loadCaseNotes: true, fnId: 25 });
  }
}

describe('HomeComponent', () => {
  let component: HomeComponent;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      providers : [
        HomeComponent,
        { provide : ActivatedRoute, useClass: MockActivatedRoute }
      ]
    }).compileComponents();
  });

  beforeEach(() => {
    component = TestBed.inject(HomeComponent);
  });

  it('should create', () => {
    expect(component).toBeTruthy();   // Assert
  });

  it(`should have as title 'POC Demo' after construction`, () => {
    expect(component.title).toEqual('POC Demo');    // Assert
  });
  
  it(`should have as loadCaseNotes to be false after construction`, () => {
    expect(component.title).toEqual('POC Demo');    // Assert
  });

  it(`should have as loadCaseNotes set after calling ngOnInit`, () => {
    component.ngOnInit();   // Act
    
    expect(component.loadCaseNotes).toBeTrue();   // Assert
  });

  it(`should have as fnid set after calling ngOnInit`, () => {
    component.ngOnInit();   // Act

    expect(component.fnid).toBe(25);    // Assert
  });
});