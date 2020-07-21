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
    public class Rectangle : Figure        //Прямоугольник_______________________________________________________________________
    {
        public Rectangle(int x, int y, int width, int heigth, ConsoleColor color)
            :base (x, y, width, heigth, color) { }

        public override void DrawFirure()
        {
            Console.ForegroundColor = color;
            for (int i=x; i < x + width; i++)
            {
                for (int j = y; j < y+heigth; j++)
                {
                    Console.SetCursorPosition(i,j);
                    Console.Write("*");
                }   
            }
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
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + heigth; j++)
                {
                    Console.SetCursorPosition(i+j, j);
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
    class Triangle : Figure             //Треугольник________________________________________________________________________
    {
        public Triangle(int x, int y, int width, int heigth, ConsoleColor color)
            : base(x, y, width, heigth, color) { }
        public override void DrawFirure()
        {
            Console.ForegroundColor = color;
            for (int i = x; i < x + width; i++)
            {
                for (int j = y; j < y + heigth; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write("*");
                }
            }
            Console.ResetColor();
        }
    }














    public class CompositeFigure        //Составная фигура_______________________________________________________________________
    {
        public void DrawAll(Figure[] composite)
        {
            foreach (Figure item in composite)
            {
                //Figure.DrawFigure();



            }
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Домашнее задание №6.2. Фигуры.";

            //Figure Rectangle_1 = new Rectangle(2, 5, 10, 5, ConsoleColor.Green);
            //Rectangle_1.DrawFirure();

            //Figure Rhombus_1 = new Rhombus(10, 10, 5, 5, ConsoleColor.Red);
            //Rhombus_1.DrawFirure();

            Figure Triangle_1 = new Triangle(5, 5, 10, 10, ConsoleColor.Blue);
            Triangle_1.DrawFirure();


            //Figure[] Figures = {
            //    new Rectangle(2,2,5,7,ConsoleColor.Green),
            //    new Rectangle(10,10,10,15,ConsoleColor.Yellow)

            //};
            //CompositeFigure MyFigures = new CompositeFigure();

            //CompositeFigure.DrawAll(Figures);





            Console.ReadKey();
        }
    }
}