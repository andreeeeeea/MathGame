namespace MathGame;

class Program
{
    private static int userPoints = 0;
    private static List<String> previousGames = new List<String>();

    private static List<int> GetNums(int op){
        List<int> nums = new List<int>();
            var random = new Random();

            var a = random.Next(1, 101);
            var b = random.Next(1, 101);

            if (op == 4){
                while (a % b != 0){
                    a = random.Next(1, 101);
                    b = random.Next(1, 101);
                }
            }

            return [a, b];
    }

    private static void UpdateScore(bool correct){
        if(correct){
            userPoints++;
        } else {
            if(userPoints > 0) userPoints--;
            else userPoints = 0;
        }
    }

    private static void UpdatePreviousGames(string game){
        previousGames.Add(game);
    }

    private static int GetOp(){
        var random = new Random();
        return random.Next(1, 5);
    }

    static void Main(string[] args)
    {
        while(true){
            Console.WriteLine("############   Welcome to the Math Game!  ############");
            Console.WriteLine($"---> Current score is {userPoints} <---");
            Console.WriteLine();
            Console.WriteLine("Please choose an operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random Continuous Mode!");
            Console.WriteLine("6. View Previous Games");
            Console.WriteLine("7. Exit");

            var choice = Int32.Parse(Console.ReadLine());
            if(choice < 1 || choice > 7){
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            List<int> nums = GetNums(choice);

            switch (choice) {
                case 1:
                    Console.WriteLine($"{nums[0]} + {nums[1]} = ?");
                    var answer = Int32.Parse(Console.ReadLine());
                    var correct = nums[0] + nums[1];
                    if (answer == correct){
                        Console.WriteLine("Correct!");
                    } else {
                        Console.WriteLine($"Incorrect! The correct answer is {correct}.");
                    }
                    UpdateScore(answer == correct);
                    UpdatePreviousGames($"{nums[0]} + {nums[1]} = {answer}");
                    break;
                case 2: 
                    Console.WriteLine($"{nums[0]} - {nums[1]} = ?");
                    answer = Int32.Parse(Console.ReadLine());
                    correct = nums[0] - nums[1];
                    if (answer == correct){
                        Console.WriteLine("Correct!");
                    } else {
                        Console.WriteLine($"Incorrect! The correct answer is {correct}.");
                    }
                    UpdateScore(answer == correct);
                    UpdatePreviousGames($"{nums[0]} - {nums[1]} = {answer}");
                    break;
                case 3:
                    Console.WriteLine($"{nums[0]} * {nums[1]} = ?");
                    answer = Int32.Parse(Console.ReadLine());
                    correct = nums[0] * nums[1];
                    if (answer == correct){
                        Console.WriteLine("Correct!");
                    } else {
                        Console.WriteLine($"Incorrect! The correct answer is {correct}.");
                    }
                    UpdateScore(answer == correct);
                    UpdatePreviousGames($"{nums[0]} * {nums[1]} = {answer}");
                    break;
                case 4:
                    Console.WriteLine($"{nums[0]} / {nums[1]} = ?");
                    answer = Int32.Parse(Console.ReadLine());
                    correct = nums[0] / nums[1];
                    if (answer == correct){
                        Console.WriteLine("Correct!");
                    } else {
                        Console.WriteLine($"Incorrect! The correct answer is {correct}.");
                    }
                    UpdateScore(answer == correct);
                    UpdatePreviousGames($"{nums[0]} / {nums[1]} = {answer}");
                    break;
                case 5:
                    while (true){
                        int randomOp = GetOp();
                        List<int> randomNums = GetNums(randomOp);
                        string opSymbol = randomOp switch {
                            1 => "+",
                            2 => "-",
                            3 => "*",
                            4 => "/",
                            _ => "+"
                        };

                        Console.WriteLine($"{randomNums[0]} {opSymbol} {randomNums[1]} = ?");
                        answer = Int32.Parse(Console.ReadLine());
                        correct = randomOp switch {
                            1 => randomNums[0] + randomNums[1],
                            2 => randomNums[0] - randomNums[1],
                            3 => randomNums[0] * randomNums[1],
                            4 => randomNums[0] / randomNums[1],
                            _ => randomNums[0] + randomNums[1]
                        };
                        if (answer == correct){
                            Console.WriteLine("Correct!");
                        } else {
                            Console.WriteLine($"Incorrect! The correct answer is {correct}.");
                        }
                        UpdateScore(answer == correct);
                        UpdatePreviousGames($"{randomNums[0]} {opSymbol} {randomNums[1]} = {answer}");
                        Console.WriteLine($"---> Current score is {userPoints} <---");
                        Console.WriteLine("Press enter to continue, or 5 to exit!");
                        if(Console.ReadLine() == "5"){
                            break;
                        }
                    }
                    break;
                case 6:
                    if(previousGames.Count == 0){
                        Console.WriteLine("No previous games to display.");
                    }
                    else {
                        Console.WriteLine("Previous Games:");
                        foreach (var game in previousGames){
                            Console.WriteLine(game);
                        }
                    }
                    break;
                case 7:
                    Console.WriteLine("Thanks for playing!");
                    return;
            }
        }
    }
}
