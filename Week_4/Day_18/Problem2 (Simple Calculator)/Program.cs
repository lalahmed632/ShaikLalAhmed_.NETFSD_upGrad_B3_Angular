using System;

namespace Problem2{
	
	class Calculator{
		
    static void Main(String[] args){
		int num1;
		int num2;
		char operators;
		
        Console.WriteLine("Enter first number:  ");
        if(!int.TryParse(Console.ReadLine(),out num1)){
			Console.WriteLine("Invalid first number ");
			return;
		}

        Console.WriteLine("Enter Second number:  ");
		if(!int.TryParse(Console.ReadLine(),out num2)){
			Console.WriteLine("Invalid Second number ");
			return;
		}

        Console.WriteLine("Enter anyy Operator { +  -  *  / }:  ");
		if(!char.TryParse(Console.ReadLine(),out operators)){
			Console.WriteLine("Invalid Operator ");
			return;
		}

        int ans = 0;

        switch (operators) {
            case '+':
                ans = num1 + num2;
                break;

            case '-':
                ans = num1 - num2;
                break;

            case '*':
                ans = num1 * num2;
                break;

            case '/':
                ans = num1 / num2;
                break;

            default:
                Console.WriteLine("Invalid Operation");
                Console.ReadLine();
                return;               
            }
			
        Console.WriteLine("Final Result : " + ans);

        Console.ReadLine();
        }
		
	}
}
