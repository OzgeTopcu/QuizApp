import { Option } from "./option.model";
 
export interface Question {
    isCorrect: boolean;
    questionId: number;
    examId: number;
    text: string;
    options: Option[];
 
}