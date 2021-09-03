import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  let component: AppComponent;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      providers: [
        AppComponent
      ],
    }).compileComponents();
  });

  beforeEach(() => {
    component = TestBed.inject(AppComponent);
  });

  it('should create', () => {
    expect(component).toBeTruthy();   // Assert
  });
});
