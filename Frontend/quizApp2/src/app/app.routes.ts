import { Routes } from '@angular/router';
import { ExamComponent } from './components/exam/exam.component';
import { HomeComponent } from './components/home/home.component';
import { OutcomeComponent } from './components/outcome/outcome.component';
import { AppComponent } from './app.component';

export const routes: Routes = [ { 
    path: '', component: HomeComponent }, 
    { path: 'exam/:examId', component: ExamComponent },
    { path: 'outcome', component: OutcomeComponent }];
