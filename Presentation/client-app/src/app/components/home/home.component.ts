import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  readonly title = 'POC Demo';
  loadCaseNotes = false;
  fnid?: number;

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.getRouteParams();
  }

  private getRouteParams() {
    this.route.paramMap.subscribe(params => {
      let loadNotes = params.get('loadCaseNotes');
      let fnid = params.get('fnId');

      if (loadNotes !== null) {
        this.loadCaseNotes = JSON.parse(loadNotes);
      }
      if (fnid !== null) {
        this.fnid = +fnid;
      }
    });
  }
}
