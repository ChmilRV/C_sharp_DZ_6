using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*2 Написать приложение, которое будет отображать в консоли простейшие геометрические фигуры заданные пользователем.
Пользователь выбирает фигуру и задает ее расположение на экране, а также размер и цвет с помощью меню.
Все заданные пользователем фигуры отображаются одновременно на экране.
Фигуры (прямоугольник, ромб, треугольник, трапеция, многоугольник) рисуются звездочками или другими символами.
Для реализациипрограммы необходимо разработать иерархию классов (продумать возможность абстрагирования).
Для хранения всех заданных пользователем фигур создать класс «Коллекция геометрических фигур» с методом «Отобразить все фигуры».
Чтобы отобразить все фигуры указанным методом требуется использовать оператор foreach,
для чего в классе «Коллекция геометрических фигур» необходимо реализовать соответствующие интерфейсы.*/
namespace C_sharp_DZ_6_2
{





    public class round1
    {
        public void DrawRound()
        {
            for (int i = 0; i < r; i++)
            {
                x = (int)Math.Round(Math.Sqrt((Math.Pow(r, 2) - Math.Pow(y, 2))));
                Console.SetCursorPosition(x + r, y + r);
                Console.WriteLine('*');
                Console.SetCursorPosition(x + r, -y + r);
                Console.WriteLine('*');
                Console.SetCursorPosition(-x + r, -y + r);
                Console.WriteLine('*');
                Console.SetCursorPosition(-x + r, y + r);
                Console.WriteLine('*');
            }
        }

    }



    public class rhombus
    {
        public void DrawRhombus()
        {

            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.WriteLine("*");

                Console.SetCursorPosition(x + size, y + size);
                Console.WriteLine("*");
                Console.SetCursorPosition(x + i, y + i);
                Console.WriteLine("*");
                Console.SetCursorPosition(x - i, y - i);
                Console.WriteLine("*");


            }
        }
    }


}




class Program
    {
        static void Main(string[] args)
        {





        }
    }
}
