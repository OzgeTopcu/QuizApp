import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Exam } from '../../models/exam.model';
import { ExamService } from '../../services/exam.service';
import { Route, Router, RouterLink } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';
 
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule,HttpClientModule, RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
 
})
export class HomeComponent implements OnInit {
  exams: Exam[] = [];
 
 
  constructor(private examService: ExamService, private router: Router) { }
 
  ngOnInit(): void {
    this.examService.getExam().subscribe((result: any) => {
      console.log('result', result)
      this.exams = result.data;
      console.log('exams loaded', this.exams);
    });
  }
 
  selectExam(examId: Number): void {
    this.router.navigate(['/exam', examId]);
  }

  startExam(examId: Number): void {
    this.router.navigate(['/exam', examId]);
  }
}
 
 
 
 
 