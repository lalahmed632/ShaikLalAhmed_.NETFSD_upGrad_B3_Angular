
import { Student }           from "./student.model";
import { PASS_MARKS, APP_NAME, MAX_MARKS } from "./constants";
import { formatName, calculateAverage, getPercentage, sortByMarks } from "./utils";
import {
  getGrade,
  getTopper,
  getPassedStudents,
  getFailedStudents,
  getResultSummary,
} from "./student.service";

// ─── Sample Data ──────────────────────────────────────────────
const students: Student[] = [
  { id: 1, name: "alice johnson",  marks: 92 },
  { id: 2, name: "bob smith",      marks: 35 },
  { id: 3, name: "carol white",    marks: 78 },
  { id: 4, name: "david brown",    marks: 55 },
  { id: 5, name: "eve davis",      marks: 88 },
  { id: 6, name: "frank miller",   marks: 40 },
  { id: 7, name: "grace wilson",   marks: 15 },
  { id: 8, name: "henry moore",    marks: 67 },
];

// ─── Header ───────────────────────────────────────────────────
console.log("═══════════════════════════════════════════════");
console.log(`  ${APP_NAME}`);
console.log("═══════════════════════════════════════════════");
console.log(`  Pass Marks : ${PASS_MARKS}`);
console.log(`  Max Marks  : ${MAX_MARKS}`);
console.log(`  Students   : ${students.length}`);
console.log("═══════════════════════════════════════════════\n");

// ─── 1. Formatted Names ───────────────────────────────────────
console.log(" Formatted Student Names:");
students.forEach(s => {
  console.log(`  • ${formatName(s.name)}`);
});

// ─── 2. Grades for each student ───────────────────────────────
console.log("\n Student Report Card:");
console.log("─────────────────────────────────────────────────");
students.forEach(s => {
  const formatted = formatName(s.name).padEnd(18);
  const grade = getGrade(s.marks);
  const pct   = getPercentage(s.marks, MAX_MARKS);
  const pass  = s.marks >= PASS_MARKS ? "✅ PASS" : "❌ FAIL";
  console.log(`  ${formatted}  Marks: ${String(s.marks).padStart(3)}  Grade: ${grade}  (${pct})  ${pass}`);
});
console.log("─────────────────────────────────────────────────");

// ─── 3. Average Marks ─────────────────────────────────────────
const avg = calculateAverage(students);
console.log(`\n Class Average : ${avg} / ${MAX_MARKS}  (${getPercentage(avg, MAX_MARKS)})`);

// ─── 4. Topper ────────────────────────────────────────────────
const topper = getTopper(students);
console.log(`\n Class Topper  : ${formatName(topper.name)} with ${topper.marks} marks (Grade: ${getGrade(topper.marks)})`);

// ─── 5. Passed / Failed split ─────────────────────────────────
const passed = getPassedStudents(students);
const failed = getFailedStudents(students);

console.log(`\n Passed Students (${passed.length}):`);
passed.forEach(s => console.log(`   • ${formatName(s.name)} — ${s.marks} marks`));

console.log(`\n Failed Students (${failed.length}):`);
failed.forEach(s => console.log(`   • ${formatName(s.name)} — ${s.marks} marks`));

// ─── 6. Ranked list ───────────────────────────────────────────
const ranked = sortByMarks(students);
console.log("\n  Students Ranked by Marks:");
ranked.forEach((s, i) => {
  console.log(`  ${String(i + 1).padStart(2)}. ${formatName(s.name).padEnd(18)}  ${s.marks} marks`);
});

// ─── 7. Result Summary ────────────────────────────────────────
console.log("\n Full Result Summaries:");
students.forEach(s => {
  const summary = getResultSummary({ ...s, name: formatName(s.name) });
  console.log(`  → ${summary}`);
});
