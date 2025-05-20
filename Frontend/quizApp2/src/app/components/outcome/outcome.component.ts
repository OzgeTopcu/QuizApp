import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
@Component({
  selector: 'app-outcome',
  templateUrl: './outcome.component.html',
  styleUrls: ['./outcome.component.css'],
  standalone: true,
  imports: [CommonModule, HttpClientModule, RouterLink]
})
export class OutcomeComponent implements OnInit {
  correctAnswers: number = 0;
  incorrectAnswers: number = 0;
  totalQuestions: number = 0;
  percentage: number = 0;
  score: number = 0;
 
  constructor(private route: ActivatedRoute) { }
 
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.correctAnswers = +params['correct'] || 0;
      this.incorrectAnswers = +params['incorrect'] || 0;
      this.totalQuestions = +params['total'] || 0;
      this.percentage = +params['percentage'] || 0;
      this.score = +params['score'] || 0;
    });
  }
}
 
 