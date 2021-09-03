import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Api } from 'src/app/shared/api';
import { FnCardService } from './fn-card.service';

describe('FnCardService', () => {
  let service: FnCardService;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ],
      providers: [ FnCardService ]
    }).compileComponents();
  });

  beforeEach(() => {
    service = TestBed.inject(FnCardService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();   // Assert
  });

  it('should make a get request to url when getFNInfo is called', () => {
    // Act
    service.getFNInfo().subscribe();

    // Assert
    const request = httpMock.expectOne({method: 'GET', url: `${Api.FNInfoUrl}/1675136072`});
    expect(request.request.url).toBe(`${Api.FNInfoUrl}/1675136072`);
    expect(request.request.method).toBe('GET');
  });
});
