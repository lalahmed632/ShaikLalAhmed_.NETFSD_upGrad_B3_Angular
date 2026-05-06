import { Student } from "./student.model";
import { PASS_MARKS, GRADE_THRESHOLDS } from "./constants";

export function getGrade(marks: number): string {
  if (marks >= GRADE_THRESHOLDS.A_PLUS) return "A+";
  if (marks >= GRADE_THRESHOLDS.A)      return "A";
  if (marks >= GRADE_THRESHOLDS.B)      return "B";
  if (marks >= GRADE_THRESHOLDS.C)      return "C";
  if (marks >= GRADE_THRESHOLDS.D)      return "D";
  return "F";
}

export function getTopper(students: Student[]): Student {
  if (students.length === 0) {
    throw new Error("Cannot find topper: student list is empty.");
  }
  return students.reduce((top, s) => (s.marks > top.marks ? s : top));
}

export function getPassedStudents(students: Student[]): Student[] {
  return students.filter(s => s.marks >= PASS_MARKS);
}

export function getFailedStudents(students: Student[]): Student[] {
  return students.filter(s => s.marks < PASS_MARKS);
}

export function getResultSummary(student: Student): string {
  const grade  = getGrade(student.marks);
  const result = student.marks >= PASS_MARKS ? "PASS" : "FAIL";
  return `${student.name} — Marks: ${student.marks} | Grade: ${grade} | Result: ${result}`;
}
