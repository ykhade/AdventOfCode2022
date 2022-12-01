namespace Day01
{
    internal static class Program
    {
        private static readonly string[] BackPackData = File.ReadAllLines("input.txt");

        static void Main()
        {
            Console.WriteLine($"Part 1:\n The highest amount of calories an elf is carrying is: {FindMostCalories(BackPackData)}\n\n");
            Console.WriteLine($"Part 2 Final Answer:\n The top three elves calorie sum: {TopThreeCaloriesSum(BackPackData)}");
        }

        private static int FindMostCalories(string[] weights) {
            var currentHeavy = 0;
            var currentElf = 0;
            foreach (var weight in weights)
            {
                if (weight == "")
                {
                    if (currentElf > currentHeavy)
                    {
                        currentHeavy = currentElf;
                    }

                    currentElf = 0;
                }
                else
                {
                    currentElf += int.Parse(weight);
                }
            }

            return currentHeavy;
        }

        private static int TopThreeCaloriesSum(string[] weights) {
            var allTheWeights = new List<int>();
            var currentElf = 0;
            foreach (var weight in weights)
            {
                if (weight == "")
                {
                    allTheWeights.Add(currentElf);

                    currentElf = 0;
                }
                else
                {
                    currentElf += int.Parse(weight);
                }
            }

            var topThree = allTheWeights.OrderByDescending(a => a).Take(3);
            var enumerable = topThree as int[] ?? topThree.ToArray();
            Console.WriteLine("Part 2:");
            foreach (var weight in enumerable)
            {
                Console.WriteLine($"Top three loads {weight}");    
            }

            return enumerable.Sum(a => a);
        }
    }
}