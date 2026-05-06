

// Student Grade Evaluator - Problem1


using System;

namespace Problem1{
	
	class StudentGrade{
		
		static void Main(String[] args){
			
			String name;
			int marks;
			
			Console.WriteLine("Enter Student name ");	
			name = Console.ReadLine() ?? "";  //null coalescing, if null then stores empty string
			
			Console.WriteLine("Enter Student marks ");
			marks = Convert.ToInt32(Console.ReadLine());
			
			Console.WriteLine("--------------------------");
			
			if(marks<=0 || marks>=100){
				Console.WriteLine("Invalid marks, Enter correct marks ");
				return;
			}
			else if(marks >=90){
				Console.WriteLine("Student name "+name);
				Console.WriteLine("Grade A");
			}
			else if(marks >=70){
				Console.WriteLine("Student name "+name);
				Console.WriteLine("Grade B");
			}
			else if(marks >=50){
				Console.WriteLine("Student name "+name);
				Console.WriteLine("Grade C");
			}
			else if(marks>=40){
				Console.WriteLine("Student name "+name);
				Console.WriteLine("Grade D");
			}
			else{
				Console.WriteLine("Student name "+name);
				Console.WriteLine("Fail");
			}
		}
	}
}