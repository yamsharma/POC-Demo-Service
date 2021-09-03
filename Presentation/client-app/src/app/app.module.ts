import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { AppRoutingModule } from './app-routing.module';
import { AddEditFnCaseNoteComponent } from './components/add-edit-fn-case-note/add-edit-fn-case-note.component';
import { AddEditFnCaseNoteService } from './components/add-edit-fn-case-note/add-edit-fn-case-note.service';
import { AppComponent } from './components/app.component';
import { FnCardComponent } from './components/fn-card/fn-card.component';
import { FnCardService } from './components/fn-card/fn-card.service';
import { FnCaseNotesComponent } from './components/fn-case-notes/fn-case-notes.component';
import { FnCaseNotesService } from './components/fn-case-notes/fn-case-notes.service';
import { HomeComponent } from './components/home/home.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { GlobalErrorHandler } from './shared/error-handlers/global-error-handler';
import { ServerErrorInterceptor } from './shared/interceptors/server-error-interceptor';

@NgModule({
  declarations: [
    AppComponent,
    FnCardComponent,
    FnCaseNotesComponent,
    NavMenuComponent,
    HomeComponent,
    AddEditFnCaseNoteComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FontAwesomeModule,
    FormsModule,
    TooltipModule.forRoot()
  ],
  providers: [
    FnCaseNotesService,
    FnCardService,
    AddEditFnCaseNoteService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ServerErrorInterceptor,
      multi: true,
    },
    {
      provide: ErrorHandler,
      useClass: GlobalErrorHandler,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
