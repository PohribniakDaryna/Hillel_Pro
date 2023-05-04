namespace LINQ
{
    public class Numbers
    {
        public static void DoActionWithArray()
        {
            Action<IEnumerable<int>> print = (list) =>
            {
                foreach (var item in list)
                {
                    Console.Write($"{item} ");
                }
            };

            //task 1
            Console.WriteLine("\n1.Created array:");
            int minValue = 1;
            int maxValue = 10;
            int[] array = new int[maxValue];

            for (int i = 0; i < maxValue; i++)
            {
                array[i] = i + minValue;
            }
            print(array);

            //variant 1

            //task 2
            Console.WriteLine("\n2.Odd number array:");
            int[] oddNumbers = array
                .Where(x => x % 2 != 0)
                .ToArray();
            print(oddNumbers);

            //task 3
            Console.WriteLine("\n3.Square of odd numbers:");
            int[] oddNumbersSquared = oddNumbers
                              .Select(x => x * x)
                              .ToArray();
            print(oddNumbersSquared);

            //task 4
            Console.WriteLine("\n4.Sum odd numbers squared:");
            int sum = oddNumbersSquared.Sum();
            Console.WriteLine(sum);

            //variant 2
            int sum1 = array.Where(x => x % 2 != 0)
                    .Select(x => x * x)
                    .Sum();
            Console.WriteLine(sum1);

            //variant 3
            int sum2 = (
            from num in array
            where num % 2 != 0
            select num * num
            ).Sum();
            Console.WriteLine(sum2);
        }
    }
}