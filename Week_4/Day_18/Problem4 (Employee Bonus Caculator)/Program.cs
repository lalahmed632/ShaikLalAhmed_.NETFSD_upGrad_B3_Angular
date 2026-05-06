using System;

namespace Problem4{
	
    class NumberAnalysis{
		
        static void Main(string[] args){
			
            int N;
            Console.WriteLine("Enter Number:");

            if(!int.TryParse(Console.ReadLine(), out N)){
                Console.WriteLine("Invalid number");
                return;
            }
			
            if(N <= 0){
                Console.WriteLine("Number must be greater than 0");
                return;
            }

            int evenCount = 0;
            int oddCount = 0;
            int sum = 0;

            for(int i = 1; i <= N; i++){
                sum += i;

                if(i % 2 == 0){
                    evenCount++;
                }
                else{
                    oddCount++;
                }
            }

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Even Count: " + evenCount);
            Console.WriteLine("Odd Count: " + oddCount);
            Console.WriteLine("Sum: " + sum);
        }
    }
}