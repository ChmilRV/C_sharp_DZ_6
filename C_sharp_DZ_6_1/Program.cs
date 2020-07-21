using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*1 Разработать абстрактный класс Геометрическая Фигура с полями ПлощадьФигуры и ПериметрФигуры.
Разработать классы-наследники: Треугольник, Квадрат, Ромб, Прямоугольник, Параллелограмм, Трапеция, Круг, Эллипс и
реализовать свойства, которые однозначно определяют объекты данных классов.
Реализовать интерфейс ПростойНУгольник, который имеет свойства: Высота, Основание,
УголМеждуОснованиемИСмежнойСтороной, КоличествоСторон, Длины Сторон, Площадь, Периметр.
Реализовать класс СоставнаяФигура который может состоять из любого количества ПростыхНУгольников
Для данного класса определить метод нахождения площади фигуры.
Предусмотреть варианты невозможности задания фигуры (введены отрицательные длины сторон или при
создании объекта треугольника существует пара сторон, сумма длин которых меньше длины третьей стороны и т п ).*/
namespace C_sharp_DZ_6_1
{
    public abstract class Figure        //Фигура

    {
        public abstract double Area();
        public abstract double Perimeter();
        public virtual void Print()
        {
            Console.WriteLine("\nФигура");
        }
        public void PrintAreaPerim()
        {
            Console.WriteLine($"Периметр: {Perimeter():F2}");
            Console.WriteLine($"Площадь: {Area():F2}");
        }
    }

    class Triangle : Figure     //Треугольник________________________________________________________________________
    {
        double side1;
        double side2;
        double side3;
        public string FigureName { get; set; }
        public double Side1
        {
            get { return side1; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать треугольник с нулевой стороной.\nПримем длину первой стороны равной 1.");
                    side1 = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать треугольник с отрицательной стороной.\nПримем длину первой стороны равной модулю введенного числа.");
                    side1 = Math.Abs(value);
                }
                else side1 = value;
            }
        }
        public double Side2
        {
            get { return side2; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать треугольник с нулевой стороной.\nПримем длину второй стороны равной 1.");
                    side2 = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать треугольник с отрицательной стороной.\nПримем длину второй стороны равной модулю введенного числа.");
                    side2 = Math.Abs(value);
                }
                else side2 = value;
            }
        }
        public double Side3
        {
            get { return side3; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать треугольник с нулевой стороной.\nПримем длину третьей стороны равной 1.");
                    value = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать треугольник с отрицательной стороной.\nПримем длину третьей стороны равной модулю введенного числа.");
                    value = Math.Abs(value);
                }
                else if (value >= Side1 + Side2)
                {
                    Console.WriteLine("Нарушено правило существования треугольника.\nСумма длин двух его сторон больше длины третьей стороны.");
                    side3 = Side1 + Side2 - 1;
                    Console.WriteLine($"Примем третью сторону равной {side3}.");
                }
                else side3 = value;
            }
        }
        public override double Area()
        {
            double p = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }
        public override double Perimeter()
        {
            return Side1 + Side2 + Side3; 
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine(FigureName);
            Console.WriteLine($"Первая сторона: {Side1}");
            Console.WriteLine($"Вторая сторона: {Side2}");
            Console.WriteLine($"Третья сторона: {Side3}");
            PrintAreaPerim();
        }
    }
    class Square : Figure       //Квадрат_______________________________________________________________________
    {
        double side;
        public string FigureName { get; set; }
        public double Side
        {
            get { return side; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать квадрат с нулевой стороной.\nПримем длину стороны равной 1.");
                    side = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать квадрат с отрицательной стороной.\nПримем длину стороны равной модулю введенного числа.");
                    side = Math.Abs(value);
                }
                else side = value;
            }
        }
        public override double Area()
        {
            return Math.Pow(Side,2);
        }
        public override double Perimeter()
        {
            return Side * 4;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(FigureName);
            Console.WriteLine($"Сторона: {Side}");
            PrintAreaPerim();
        }
    }
    class Rectangle : Figure        //Прямоугольник_______________________________________________________________________
    {
        private double side1;
        private double side2;
        public string FigureName { get; set; }
        public double Side1
        {
            get { return side1; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать прямоугольник с нулевой стороной.\nПримем длину первой стороны равной 1.");
                    side1 = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать прямоугольник с отрицательной стороной.\nПримем длину первой стороны равной модулю введенного числа.");
                    side1 = Math.Abs(value);
                }
                else side1 = value;
            }
        }
        public double Side2
        {
            get { return side2; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать прямоугольник с нулевой стороной.\nПримем длину второй стороны равной 1.");
                    side2 = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать прямоугольник с отрицательной стороной.\nПримем длину второй стороны равной модулю введенного числа.");
                    side2 = Math.Abs(value);
                }
                else side2 = value;
            }
        }
        public override double Area()
        {
            return Side1 * Side2;
        }
        public override double Perimeter()
        {
            return (Side1 + Side2) * 2;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(FigureName);
            Console.WriteLine($"Первая сторона: {Side1}");
            Console.WriteLine($"Вторая сторона: {Side2}");
            PrintAreaPerim();
        }
    }
    class Rhombus : Figure      //Ромб_______________________________________________________________________
    {
        private double side;
        private double angle;
        public string FigureName { get; set; }
        public double Side
        {
            get { return side; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать ромб с нулевой стороной.\nПримем длину стороны равной 1.");
                    side = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать ромб с отрицательной стороной.\nПримем длину стороны равной модулю введенного числа.");
                    side = Math.Abs(value);
                }
                else side = value;
            }
        }
        public double Angle
        {
            get { return angle; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать ромб с нулевым углом.\nПримем угол равным 45 гр.");
                    angle = 45;
                }
                else if (value < 0)
                {
                    angle = Math.Abs(value);
                }
                else angle = value;
            }
        }
        public override double Area()
        {
            return Math.Pow(Side, 2) * Math.Sin(Angle * Math.PI / 180);
        }
        public override double Perimeter()
        {
            return Side * 4;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(FigureName);
            Console.WriteLine($"Сторона: {Side}");
            Console.WriteLine($"Угол между сторонами: {Angle}");
            PrintAreaPerim();
        }
    }
    class Parallelogram : Figure       //Параллелограмм_______________________________________________________________________
    {
        private double side1;
        private double side2;
        private double angle;
        public string FigureName { get; set; }
        public double Side1
        {
            get { return side1; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать параллелограмм с нулевой стороной.\nПримем длину первой стороны равной 1.");
                    side1 = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать параллелограмм с отрицательной стороной.\nПримем длину первой стороны равной модулю введенного числа.");
                    side1 = Math.Abs(value);
                }
                else side1 = value;
            }
        }
        public double Side2
        {
            get { return side2; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать параллелограмм с нулевой стороной.\nПримем длину второй стороны равной 2.");
                    side2 = 2;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать параллелограмм с отрицательной стороной.\nПримем длину второй стороны равной модулю введенного числа.");
                    side2 = Math.Abs(value);
                }
                else side2 = value;
            }
        }
        public double Angle
        {
            get { return angle; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать параллелограмм с нулевым углом.\nПримем угол равным 45 гр.");
                    angle = 45;
                }
                else if (value < 0)
                {
                    angle = Math.Abs(value);
                }
                else angle = value;
            }
        }
        public override double Area()
        {
            return Side1 * Side2 * Math.Sin(Angle * Math.PI / 180);
        }
        public override double Perimeter()
        {
            return (Side1 + Side2) * 2;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(FigureName);
            Console.WriteLine($"Первая сторона: {Side1}");
            Console.WriteLine($"Вторая сторона: {Side2}");
            Console.WriteLine($"Угол между сторонами: {Angle}");
            PrintAreaPerim();
        }
    }
    class Trapezoid : Figure     //Трапеция_______________________________________________________________________
    {
        double a;        //a<b
        double b;
        double c;
        double d;
        public string FigureName { get; set; }
        public double A
        {
            get { return a; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать трапецию с нулевой стороной.\nПримем длину верхнего основания равной 1.");
                    a = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать трапецию с отрицательной стороной.\nПримем длину верхнего основания равной модулю введенного числа.");
                    a = Math.Abs(value);
                }
                else a = value;
            }
        }
        public double B
        {
            get { return b; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать трапецию с нулевой стороной.\nПримем длину нижнего основания равной 2.");
                    b = 2;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать трапецию с отрицательной стороной.\nПримем длину нижнего основания равной модулю введенного числа.");
                    b = Math.Abs(value);
                }
                else b = value;
            }
        }
        public double C
        {
            get { return c; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать трапецию с нулевой стороной.\nПримем длину боковой стороны равной 1.");
                    c = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать трапецию с отрицательной стороной.\nПримем длину боковой стороны равной модулю введенного числа.");
                    c = Math.Abs(value);
                }
                else c = value;
            }
        }
        public double D
        {
            get { return d; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать трапецию с нулевой стороной.\nПримем длину боковой стороны равной 1.");
                    d = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать трапецию с отрицательной стороной.\nПримем длину боковой стороны равной модулю введенного числа.");
                    d = Math.Abs(value);
                }
                else d = value;
            }
        }
        public override double Area()
        {
            return ((A + B) / (4 * (B - A))) * Math.Sqrt((A + C + D - B) * (A + D - B - C) * (A + C - B - D) * (B + C + D - A));
        }
        public override double Perimeter()
        {
            return A + B + C + D;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(FigureName);
            Console.WriteLine($"Верхнее основание: {A}");
            Console.WriteLine($"Нижнее основание: {B}");
            Console.WriteLine($"Боковая сторона: {C}");
            Console.WriteLine($"Боковая сторона: {D}");
            PrintAreaPerim();
        }
    }
    class Circle : Figure     //Круг_______________________________________________________________________
    {
        double d;
        public string FigureName { get; set; }
        public double D
        {
            get { return d; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать круг с нулевым диаметром.\nПримем диаметр равной 1.");
                    d = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать круг с отрицательной диаметром.\nПримем диаметр равный модулю введенного числа.");
                    d = Math.Abs(value);
                }
                else d = value;
            }
        }
        public override double Area()
        {
            return Math.PI * Math.Pow(d, 2) / 4;
        }
        public override double Perimeter()
        {
            return Math.PI * d;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(FigureName);
            Console.WriteLine($"Диаметр: {D}");
            PrintAreaPerim();
        }
    }
    class Ellipse : Figure     //Эллипс_______________________________________________________________________
    {
        double a;
        double b;
        public string FigureName { get; set; }
        public double A
        {
            get { return a; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать эллипс с нулевой полуосью.\nПримем длину большой полуоси равной 2.");
                    a = 2;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать эллипс с отрицательной полуосью.\nПримем длину большой полуоси равной модулю введенного числа.");
                    a = Math.Abs(value);
                }
                else a = value;
            }
        }
        public double B
        {
            get { return b; }
            set
            {
                if (value == 0)
                {
                    Console.WriteLine("Невозможно создать эллипс с нулевой полуосью.\nПримем длину малой полуоси равной 1.");
                    b = 1;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Невозможно создать эллипс с отрицательной полуосью.\nПримем длину малой полуоси равной модулю введенного числа.");
                    b = Math.Abs(value);
                }
                else b = value;
            }
        }
        public override double Area()
        {
            return Math.PI * A * B;
        }
        public override double Perimeter()
        {
            return 4 * (Math.PI * A * B + Math.Pow(A - B, 2)) / (A + B);
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(FigureName);
            Console.WriteLine($"Большая полуось: {A}");
            Console.WriteLine($"Малая полуось: {B}");
            PrintAreaPerim();
        }
    }





    //public class CompositeFigure        //Составная фигура_______________________________________________________________________
    //{
    //    public double TotalArea = 0;
    //    public double GetTotalArea(Figure[] composite)
    //    {
    //        foreach (Figure item in composite)
    //        {
    //            TotalArea += item.Area();
    //        }
    //        return TotalArea;
    //    }
    //}






    class Program
    {
        static void Main(string[] args)
        {
            Triangle Triangle_1 = new Triangle
            {
                Side1 = 10,
                Side2 = 11,
                Side3 = 12,
                FigureName = "Треугольник"
            };
            Triangle_1.Print();
            
            Square Square_1 = new Square
            {
                Side = 20,
                FigureName = "Квадрат"
            };
            Square_1.Print();
            
            Rectangle Rectangle_1 = new Rectangle
            {
                Side1 = 12,
                Side2 = 25,
                FigureName = "Прямоугольник"
            };
            Rectangle_1.Print();
            
            Rhombus Rhombus_1 = new Rhombus
            {
                Side = 4,
                Angle = 30,
                FigureName = "Ромб"
            };
            Rhombus_1.Print();
            
            Parallelogram Parallelogram_1 = new Parallelogram
            {
                Side1 = 10,
                Side2 = 12,
                Angle = 30,
                FigureName = "Параллелограмм"
            };
            Parallelogram_1.Print();
            
            Trapezoid Trapezoid_1 = new Trapezoid
            {
                A = 10,
                B = 12,
                C = 3,
                D = 4,
                FigureName = "Трапеция"
            };
            Trapezoid_1.Print();
            Trapezoid_1.PrintAreaPerim();

            Circle Circle_1 = new Circle
            {
                D = 7,
                FigureName = "Круг"
            };
            Circle_1.Print();
            Circle_1.PrintAreaPerim();

            Figure Ellipse_1 = new Ellipse
            {
                A=12,
                B=10,
                FigureName= "Эллипс"
            };
            Ellipse_1.Print();
            //Ellipse_1.PrintAreaPerim();
 
            //Figure[] Figures = {
            //    new Triangle(10, 11, 13),
            //    new Square(10),
            //    new Rectangle(15, 29),
            //    new Rhombus(4, 30),
            //    new Parallelogram(10, 12, 30),
            //    new Trapezoid(10, 12, 3, 4),
            //    new Circle(10),
            //    new Ellipse(12, 10)
            //};
            //CompositeFigure MyFigures = new CompositeFigure();
            //Console.WriteLine($"\nОбщая площадь фигур: {MyFigures.GetTotalArea(Figures):F2}");





            Console.ReadKey();
        }
    }
}
