using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*2 Написать приложение, которое будет отображать в консоли простейшие геометрические фигуры заданные пользователем.
Пользователь выбирает фигуру и задает ее расположение на экране, а также размер и цвет с помощью меню.
Все заданные пользователем фигуры отображаются одновременно на экране.
Фигуры (прямоугольник, ромб, треугольник, трапеция, многоугольник) рисуются звездочками или другими символами.
Для реализации программы необходимо разработать иерархию классов (продумать возможность абстрагирования).
Для хранения всех заданных пользователем фигур создать класс «Коллекция геометрических фигур» с методом «Отобразить все фигуры».
Чтобы отобразить все фигуры указанным методом требуется использовать оператор foreach,
для чего в классе «Коллекция геометрических фигур» необходимо реализовать соответствующие интерфейсы.*/
namespace C_sharp_DZ_6_2
{
    public abstract class Figure        //Фигура
    {
        public int x;
        public int y;
        public int width;
        public int heigth;
        public ConsoleColor color;
        public Figure(int x, int y, int width, int heigth, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.heigth = heigth;
            this.color = color;
        }
        public abstract void DrawFirure();

    }
    public class Rectangle : Figure        //Прямоугольник____________________________________________________
    {
        public Rectangle(int x, int y, int width, int heigth, ConsoleColor color)
            :base (x, y, width, heigth, color) { }

        public override void DrawFirure()
        {
            Console.ForegroundColor = color;
            for (int i=0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    Console.SetCursorPosition(i + x, j + y);
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
    class Rhombus : Figure      //Ромб_______________________________________________________________________
    {
        public Rhombus(int x, int y, int width, int heigth, ConsoleColor color)
            : base(x, y, width, heigth, color) { }

        public override void DrawFirure()
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    Console.SetCursorPosition(i + j + x, j + y);
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
    class Triangle : Figure             //Треугольник____________________________________________________________
    {
        public Triangle(int x, int y, int width, int heigth, ConsoleColor color)
            : base(x, y, width, heigth, color) { }
        public override void DrawFirure()
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width /*heigth*/; j++)
                {
                    if (i <= j)
                    {
                        Console.SetCursorPosition(i + x, j + y);
                        Console.Write("*");
                    }
                }
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
    class Trapezoid : Figure     //Трапеция____________________________________________________________________
    {
        public Trapezoid(int x, int y, int width, int heigth, ConsoleColor color)
            : base(x, y, width, heigth, color) { }
        public override void DrawFirure()
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < heigth; j++)
                {
                    if ((i + j + 2 > heigth ) && (i - j - 1 < width - heigth))
                    {
                        Console.SetCursorPosition(i + x, j + y);
                        Console.Write("*");
                    }
                }
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
    public class CompositeFigure: IComposite       //Составная фигура_____________________________________________
    {
        public void DrawAll(Figure[] composite)
        {
            foreach (Figure item in composite)
            {
                item.DrawFirure();
            }
        }
    }
    public interface IComposite
    {
        void DrawAll(Figure[] composite);
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Домашнее задание №6.2. Фигуры снова.";
            Figure Rectangle_1 = new Rectangle(5, 5, 8, 3, ConsoleColor.Green);
            Figure Rhombus_1 = new Rhombus(10, 10, 8, 8, ConsoleColor.Red);
            Figure Triangle_1 = new Triangle(10, 15, 6, 12, ConsoleColor.Blue);
            Figure Trapezoi_1 = new Trapezoid(20, 5, 20, 5, ConsoleColor.DarkYellow);
            Figure[] Figures = {
                Rectangle_1,
                Rhombus_1,
                Triangle_1,
                Trapezoi_1
            };
            CompositeFigure MyFigures = new CompositeFigure();
            MyFigures.DrawAll(Figures);
            Console.ReadKey();
        }
    }
}