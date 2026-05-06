using System;
	
	namespace Problem3{
		
		class EmployeeBonus{
			
			static void Main(String[] args){
								
				String ename;
				double sal;
				int Yoe;
				double bonus = 0;
				
				Console.WriteLine("Enter emp name ");
				ename = Console.ReadLine() ?? "";
				if(ename==""){
					Console.WriteLine("Enter Valid name ");
					return;
				}
				
				Console.WriteLine("Enter emp sal ");
				if(!double.TryParse(Console.ReadLine(),out sal)){
					Console.WriteLine("Enter Valid sal ");
					return;
				}
				if(sal<=0){
					Console.WriteLine("sal mus be greater than zero ");
					return;
				}
				
				Console.WriteLine("Enter Years of Experience");
				if (!int.TryParse(Console.ReadLine(), out Yoe)){
					Console.WriteLine("Enter valid experience");
					return;
				}
				if (Yoe < 0){
					Console.WriteLine("Invalid experience");
					return;
				}
				
				//calculating bonus
				if (Yoe < 2){
					bonus = sal * 0.05;
				}
				else if (Yoe >= 2 && Yoe <= 5){
					bonus = sal * 0.10;
				}
				else{
					bonus = sal * 0.15;
				}
				double finalSal = sal + bonus;
				
				Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
				Console.WriteLine("Employee: " + ename);
				Console.WriteLine("Bonus: " + bonus.ToString());
				Console.WriteLine("Final Salary: " + finalSal.ToString());
			}
		}
	}	
