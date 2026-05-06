
import { Student } from "./student.model";

export function formatName(name: string): string {
  if (!name || name.trim() === "") return "";
  return name
    .trim()
    .toLowerCase()
    .split(" ")
    .map(word => word.charAt(0).toUpperCase() + word.slice(1))
    .join(" ");
}


export function calculateAverage(students: Student[]): number {
  if (students.length === 0) return 0;
  const total = students.reduce((sum, s) => sum + s.marks, 0);
  return parseFloat((total / students.length).toFixed(2));
}

export function getPercentage(marks: number, maxMarks: number): string {
  if (maxMarks === 0) return "0.00%";
  return ((marks / maxMarks) * 100).toFixed(2) + "%";
}

export function sortByMarks(students: Student[]): Student[] {
  return [...students].sort((a, b) => b.marks - a.marks);
}
