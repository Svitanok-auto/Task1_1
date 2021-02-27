using System;

namespace ConsoleApp1_1
{
    public class Figure
    {
        public double input;

        public Figure(double RadiusOrSide)
        {
            input = RadiusOrSide;
        }

        static double CalcCircle(double a)
        {
            const double Pi = Math.PI;
            double result = Math.Round((a * Pi), 2);
            return result;
        }

        static double CalcArea(double b)
        {
            double result = Math.Round(b * b, 2);
            return result;
        }

        public static void Main(string[] args)
        {
            EnterFigure(Shape.Circle);
            EnterFigure(Shape.Area);
            Console.WriteLine("The end");
            Console.ReadKey();
        }

        enum Shape
        {
            Circle,
            Area
        }

        static void EnterFigure(Shape shape)
        {
            switch (shape)
            {
                case Shape.Circle:

                    Console.WriteLine("What is the radius of the circle? Radius should be more than 0");
                    double MainResultCircle = CalcCircle(ReturnRadiusOrSide());
                    Console.WriteLine("\n\rThe square of the circle is " + MainResultCircle);
                    break;

                case Shape.Area:

                    Console.WriteLine("\nWhat is the side of the square? Should be more than 0");
                    double MainResultArea = CalcArea(ReturnRadiusOrSide());
                    Console.WriteLine("\n\rThe square of the area is " + MainResultArea);
                    break;
            }
        }

        public static double ReturnRadiusOrSide()
        {
            int e = 0;
            while (e < 3)
            {
                string InputString = Console.ReadLine();
                if (InputString.ToString() != string.Empty) // the Convert fails when ""
                {
                    try
                    {
                        double RadiusOrSideTest = Convert.ToDouble(InputString);
                        var CircleOrArea = new Figure(RadiusOrSideTest) { };
                        Console.WriteLine("\nInput Value is " + CircleOrArea.input);
                        return CircleOrArea.input;
                    }

                    catch (SystemException sex)
                    {
                        // this class's error string
                        string LastError = sex.Message;
                        Console.WriteLine("\nIncorrect Input, error" + LastError +" \nTry again otherwise random value will be taken");
                        e++;
                    }
                }
                else
                {
                    Console.WriteLine("\nEmpty input");
                }
            }

            if (e == 3)
            {
                double minNumber = 0.5;
                double maxNumber = 5.0;
                double RadiusOrSide = new Random().NextDouble() * (maxNumber - minNumber) + minNumber;
                Figure OtherCircleOrArea = new Figure(RadiusOrSide) { };
                Console.WriteLine("\nRandom value is " + OtherCircleOrArea.input);
                return OtherCircleOrArea.input;
            }
            return 0;
        }

    }
}
