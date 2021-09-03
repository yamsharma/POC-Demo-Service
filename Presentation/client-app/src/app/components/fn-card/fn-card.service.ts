import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Api } from '../../shared/api';
import { FnInfo } from '../../shared/models/fn-info.model';

@Injectable({
  providedIn: 'root',
})
export class FnCardService {
  private readonly fnId = 1675136072;

  constructor(private http: HttpClient) {}

  getFNInfo() {
    const url = `${Api.FNInfoUrl}/${this.fnId}`;
    return this.http.get<FnInfo>(url);
  }
}
