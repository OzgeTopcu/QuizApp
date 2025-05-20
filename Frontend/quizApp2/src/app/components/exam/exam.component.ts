import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink} from '@angular/router';
import { JointService } from '../../services/joint.service';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
 
 
@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: ['./exam.component.css'],
  standalone: true,
  imports: [CommonModule, RouterLink, HttpClientModule],
})
export class ExamComponent implements OnInit {
  [x: string]: any;
  questions: any[] = [];
  currentQuestionIndex: number = 0;
  currentOptions: any[] = [];
  selectedOption: number | null = null;
  correctAnswersCount: number = 0;
  incorrectAnswersCount: number = 0;
  feedback: 'correct' | 'incorrect' | null = null;
 
  constructor(private route: ActivatedRoute, private jointService: JointService, private router: Router) { }
 
  ngOnInit(): void {
    const examId = +this.route.snapshot.paramMap.get('id')!;
    if(examId){
    this.loadQuestions(examId);
    }
  }
 
  loadQuestions(examId: number): void {
    this.jointService.getExamQuestions(examId).subscribe((result: any) => {
      console.log("DATA", result);
      this.questions = result.data;
      if (this.questions.length > 0) {
        this.loadOptions(this.questions[this.currentQuestionIndex].questionId);
      }
    });
  }
 
  loadOptions(questionId: number): void {
    this.jointService.getQuestionWithOptions(questionId).subscribe((result: any) => {
      this.currentOptions = result;
    });
  }
 
  selectOption(option: any): void {
   if(this.selectedOption !== null){
    return;
   }
   else{
    this.selectedOption = option.id;
    console.log("selected",this.selectedOption);
    if (option.isCorrect) {
      this.feedback = 'correct';
      this.correctAnswersCount++;
    } 
    else {
      this.feedback = 'incorrect';
      this.incorrectAnswersCount++;
    }
  }
}
 
  getCorrectOption(): any{
    return this.currentOptions.find(o =>o.isCorrect); 
  }
 
  getCorrectAnswerText(): string {
    const correctOption = this.currentOptions.find(o => o.isCorrect);
    return correctOption ? correctOption.text : '';
  }
 
  nextQuestion(): void {
    this.feedback = null;
    this.selectedOption = null;
    this.currentQuestionIndex++;
    if (this.currentQuestionIndex < this.questions.length) {
      this.loadOptions(this.questions[this.currentQuestionIndex].questionId);
    }
    else{
      this.finishExam();
    }
  }
 
  finishExam(): void {
    const totalQuestions = this.questions.length;
    const percentage = (this.correctAnswersCount / totalQuestions) * 100;
    this.router.navigate(['/outcome'],
      {
      queryParams: {
        correct: this.correctAnswersCount,
        incorrect: this.incorrectAnswersCount,
        total: totalQuestions,
        percentage: percentage.toFixed(2)
      }
    });
  }
}