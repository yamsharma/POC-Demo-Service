import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditFnCaseNoteComponent } from './components/add-edit-fn-case-note/add-edit-fn-case-note.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'Home/:loadCaseNotes/:fnId', component: HomeComponent, pathMatch: 'full' },
  { path: 'AddCaseNote/:fnId', component: AddEditFnCaseNoteComponent, pathMatch: 'full' },
  { path: 'EditCaseNote/:fnId/:id/:title', component: AddEditFnCaseNoteComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
