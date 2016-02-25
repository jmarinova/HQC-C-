namespace Methods
{
    using System;
    using Numbers;

    public class Methods
    {
        /// <summary>
        /// calculates the area of a triangle
        /// </summary>
        /// <param name="a">side a</param>
        /// <param name="b">side b</param>
        /// <param name="c">side c</param>
        /// <returns>a double value of the area</returns>
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("sides cannot be equal or less than zeroooo");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        /// <summary>
        /// converts an int to a digit
        /// </summary>
        /// <param name="number">number to convert</param>
        /// <returns>a string value</returns>
        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "Invalid number!";
            }
        }

        /// <summary>
        /// finds max element of an int array
        /// </summary>
        /// <param name="elements">array of ints</param>
        /// <returns>the max element</returns>
        public static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("int array cannot be empty");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        /// <summary>
        /// prints an object formatted in certain way
        /// </summary>
        public static void FormatNumber(object number, string format)
        {
            switch(format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
            }
        }

       
        
        /// <summary>
        /// calculates a distance between two points
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="isHorizontal"></param>
        /// <param name="isVertical"></param>
        /// <returns>a double value of the distance</returns>
        public static double CalcDistance(double x1, double y1, double x2, double y2, out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (y1 == y2);
            isVertical = (x1 == x2);

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        /// <summary>
        /// 
        /// </summary>
        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            FormatNumber(1.3, "f");
            Numbers.Numbers.PrintToPercentageNumber(0.75, "%");
            FormatNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", "Sofia", new DateTime (1992, 03, 17));

            Student stella = new Student("Stella", "Markova", "Vidin", new DateTime(1993, 11, 03));

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
