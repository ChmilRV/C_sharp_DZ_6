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
    class Triangle : Figure     //Треугольник
    {
        private double side1;
        private double side2;
        private double side3;
        private string figureName;
        public double Side1
        {
            get
            { 
                return side1;
            }
            set
            {
                side1 = value > 0 ? value : Math.Abs(value);
                //if (value <= 0)
                //{
                //    side1=Math.Abs(value);
                //    Console.WriteLine("Попытка ввода отрицательного значения первой стороны треугольника.");
                //}
                //else side1 = value;
            }
        }
        public double Side2
        {
            get
            {
                return side2;
            }
            set
            {
                if (value <= 0)
                {
                    side2 = Math.Abs(value);
                    Console.WriteLine("Попытка ввода отрицательного значения второй стороны треугольника.");
                }
                else side2 = value;
            }
        }
        public double Side3
        {
            get
            {
                return side3;
            }
            set
            {
                if (value >= Side1+Side2)
                {
                    side3 = Side1+Side2-1;
                }
                else side3 = value;
            }
        }



        public Triangle() { }
        public Triangle(double _side1, double _side2, double _side3)
        {
            side1 = _side1;
            side2 = _side2;
            side3 = _side3;
            figureName = "Треугольник";
        }
        public override double Area()
        {
            double p = (side1 + side2 + side3) / 2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }
        public override double Perimeter()
        {
            return side1 + side2 + side3;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(figureName);
            Console.WriteLine($"Первая сторона: {side1}");
            Console.WriteLine($"Вторая сторона: {side2}");
            Console.WriteLine($"Третья сторона: {side3}");
        }
    }
    class Square : Figure       //Квадрат
    {
        public double _side1;
        public string _figureName;
        public Square(double _side1)
        {
            this._side1 = _side1;
            _figureName = "Квадрат";
        }
        public override double Area()
        {
            return _side1 * _side1;
        }
        public override double Perimeter()
        {
            return _side1 * 4;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(_figureName);
            Console.WriteLine($"Сторона: {_side1}");
        }
    }
    class Rectangle : Square        //Прямоугольник
    {
        public double _side2;
        public Rectangle(double _side1, double _side2)
            : base(_side1)
        {
            this._side2 = _side2;
            _figureName = "Прямоугольник";
        }
        public override double Area()
        {
            return _side1 * _side2;
        }
        public override double Perimeter()
        {
            return (_side1 + _side2) * 2;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Вторая сторона: {_side2}");
        }
    }
    class Rhombus : Square      //Ромб
    {
        public double _angle;
        public Rhombus(double _side1, double _angle)
            : base(_side1)
        {
            this._angle = _angle;
            _figureName = "Ромб";
        }
        public override double Area()
        {
            return Math.Pow(_side1, 2) * Math.Sin(_angle * Math.PI / 180);
        }
        public override double Perimeter()
        {
            return _side1 * 4;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Угол между сторонами: {_angle}");
        }
    }
    class Parallelogram : Rhombus       //Параллелограмм
    {
        public double _side2;
        public Parallelogram(double _side1, double _side2, double _angle)
            : base(_side1, _angle)
        {
            this._side2 = _side2;
            _figureName = "Параллелограмм";
        }
        public override double Area()
        {
            return _side1 * _side2 * Math.Sin(_angle * Math.PI / 180);
        }
        public override double Perimeter()
        {
            return (_side1 + _side2) * 2;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Угол между сторонами: {_angle}");
        }
    }
    class Trapezoid : Figure     //Трапеция
    {
        public double a;        //a<b
        public double b;
        public double c;
        public double d;
        public string _figureName;
        public Trapezoid(double a, double b, double c, double d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            _figureName = "Трапеция";
        }
        public override double Area()
        {
            return ((a + b) / (4 * (b - a))) * Math.Sqrt((a + c + d - b) * (a + d - b - c) * (a + c - b - d) * (b + c + d - a));
        }
        public override double Perimeter()
        {
            return a + b + c + d;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(_figureName);
            Console.WriteLine($"Верхнее основание: {a}");
            Console.WriteLine($"Нижнее основание: {b}");
            Console.WriteLine($"Боковая сторона: {c}");
            Console.WriteLine($"Боковая сторона: {d}");
        }
    }
    class Circle : Figure     //Круг
    {
        public double d;
        public string _figureName;
        public Circle(double d)
        {
            this.d = d;
            _figureName = "Круг";
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
            Console.WriteLine(_figureName);
            Console.WriteLine($"Диаметр: {d}");
        }
    }
    class Ellipse : Figure     //Эллипс
    {
        public double a;
        public double b;
        public string _figureName;
        public Ellipse(double a, double b)
        {
            this.a = a;
            this.b = b;
            _figureName = "Эллипс";
        }
        public override double Area()
        {
            return Math.PI * a * b;
        }
        public override double Perimeter()
        {
            return 4 * (Math.PI * a * b + Math.Pow(a - b, 2)) / (a + b);
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(_figureName);
            Console.WriteLine($"Большая полуось: {a}");
            Console.WriteLine($"Малая полуось: {b}");
        }
    }




    public class CompositeFigure        //Составная фигура
    {
        public double TotalArea = 0;
        public double GetTotalArea(Figure[] composite)
        {
            foreach (Figure item in composite)
            {
                TotalArea += item.Area();
            }
            return TotalArea;
        }
    }







    class Program
    {
        static void Main(string[] args)
        {

            Triangle Triangle_1 = new Triangle();
            Triangle_1.Side1 = -10;
            Triangle_1.Side2 = 10;
            Triangle_1.Side3 = 12;


            Triangle_1.Print();
            Triangle_1.PrintAreaPerim();



            //Figure Square_1 = new Square(10);
            //Square_1.Print();
            //Square_1.PrintAreaPerim();
            //Square Rectangle_1 = new Rectangle(15, 29);
            //Rectangle_1.Print();
            //Rectangle_1.PrintAreaPerim();
            //Square Rhombus_1 = new Rhombus(4, 30);
            //Rhombus_1.Print();
            //Rhombus_1.PrintAreaPerim();
            //Rhombus Parallelogram_1 = new Parallelogram(10, 12, 30);
            //Parallelogram_1.Print();
            //Parallelogram_1.PrintAreaPerim();
            //Figure Trapezoid_1 = new Trapezoid(10, 12, 3, 4);
            //Trapezoid_1.Print();
            //Trapezoid_1.PrintAreaPerim();
            //Figure Circle_1 = new Circle(10);
            //Circle_1.Print();
            //Circle_1.PrintAreaPerim();
            //Figure Ellipse_1 = new Ellipse(12, 10);
            //Ellipse_1.Print();
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
