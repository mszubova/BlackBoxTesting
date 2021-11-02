using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlackBoxTesting
{
    public static class ExpressionCalculator
    {
        public static double Calculate(double x1, double x2, double x3, double x4)
        {
            return Math.Abs(x2 - x1) + Math.Abs(x4 - x3);
        }
        /// <summary>
        /// Скалярное произведение вектора
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns> 
        public static double GetSkalyar(Point v1, Point v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        /// <summary>
        /// Расстояние между точками
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double GetLenght(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }
        /// <summary>
        /// Находит вектор прямой заданной двумя точками
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point GetVector(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y);
        }
        /// <summary>
        /// Проверка на коллинеарность векторов
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool IsColleniar(Point v1, Point v2)
        {
            if (v1.Y == 0 || v2.Y == 0)
                return v1.Y / v1.X == v2.Y / v2.X;
            else
                return v1.X / v1.Y == v2.X / v2.Y;
        }
        /// <summary>
        /// Проверка на ромб
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsRhomb(Point a, Point b, Point c, Point d)
        {
            double ab = GetLenght(a,b), bc = GetLenght(b, c), cd = GetLenght(c, d), da = GetLenght(d, a);
            return ab == bc && bc == cd && cd == da;
        }
        /// <summary>
        /// Проверка на квадрат
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsSquare(Point a, Point b, Point c, Point d)
        {
            return IsRectangle(a, b, c, d) && IsRhomb(a, b, c, d);
        }
        /// <summary>
        /// Проверка на парралелограм
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsParallelogram(Point a, Point b, Point c, Point d)
        {
            Point v1 = GetVector(a, b);
            Point v2 = GetVector(c, d);
            Point v3 = GetVector(b, c);
            Point v4 = GetVector(d, a);
            return IsColleniar(v1, v2) && IsColleniar(v3, v4);
        }
        /// <summary>
        /// Проверка на прямоугольник
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsRectangle(Point a, Point b, Point c, Point d)
        {
            Point v1 = GetVector(a, b);
            Point v2 = GetVector(c, d);
            Point v3 = GetVector(b, c);
            Point v4 = GetVector(d, a);
            return IsColleniar(v1, v2) && IsColleniar(v3, v4) && GetSkalyar(v1, v3) == 0 && GetSkalyar(v2, v4) == 0;
        }

        /// <summary>
        /// Проверка на трапецию
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsTrapezoid(Point a, Point b, Point c, Point d)
        {
            Point v1 = GetVector(a, b);
            Point v2 = GetVector(b, c);
            Point v3 = GetVector(c, d);
            Point v4 = GetVector(d, a);
            return (IsColleniar(v1, v3) && !IsColleniar(v2, v4)) || (!IsColleniar(v1, v3) && IsColleniar(v2, v4));
        }
        /// <summary>
        /// Проверка на равнобедренную трапецию
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsIsoscelesTrapezoid(Point a, Point b, Point c, Point d)
        {
            return (GetLenght(b, c) == GetLenght(d, a) || GetLenght(a, b) == GetLenght(c, d)) && IsTrapezoid(a, b, c, d);
        }
        /// <summary>
        /// Проверка на прямоугольную трапецию
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static bool IsRectangularTrapezoid(Point a, Point b, Point c, Point d)
        {
            Point v1 = GetVector(a, b);
            Point v2 = GetVector(b, c);
            Point v3 = GetVector(c, d);
            Point v4 = GetVector(d, a);
            return IsTrapezoid(a, b, c, d) && (GetSkalyar(v1, v2) == 0 || GetSkalyar(v3, v4) == 0);
        }
    }
}
