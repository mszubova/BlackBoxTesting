using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlackBoxTesting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnRes2_Click(object sender, RoutedEventArgs e)
        {
            Point p1;
            Point p2;
            Point p3;
            Point p4;
            try
            {
                p1 = new Point(double.Parse(TxbP1x.Text), double.Parse(TxbP1y.Text));
                p2 = new Point(double.Parse(TxbP2x.Text), double.Parse(TxbP2y.Text));
                p3 = new Point(double.Parse(TxbP3x.Text), double.Parse(TxbP3y.Text));
                p4 = new Point(double.Parse(TxbP4x.Text), double.Parse(TxbP4y.Text));
            }
            catch (Exception)
            {
                return;
            }

            if (ExpressionCalculator.IsSquare(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Квадрат";
            }
            else if (ExpressionCalculator.IsRectangle(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Прямоугольник";
            }
            else if (ExpressionCalculator.IsRhomb(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Ромб";
            }
            else if (ExpressionCalculator.IsParallelogram(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Параллелограм";
            }
            else if (ExpressionCalculator.IsIsoscelesTrapezoid(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Равнобедренная трапеция";
            }
            else if (ExpressionCalculator.IsRectangularTrapezoid(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Прямоугольная трапеция";
            }
            else if (ExpressionCalculator.IsTrapezoid(p1, p2, p3, p4))
            {
                TxbResult2.Text = "Трапеция общего вида";
            }
            else
            {
                TxbResult2.Text = "Четырехугольник общего вида";
            }
        }

        private void BtnRes1_Click(object sender, RoutedEventArgs e)
        {
            double x1, x2, x3, x4;

            if (!double.TryParse(TxbS1x1.Text, out x1))
            {
                string t = "";
                for (int i = 0; i < TxbS1x1.Text.Length; i++)
                {
                    if (char.IsDigit(TxbS1x1.Text[i]))
                    {
                        t += TxbS1x1.Text[i];
                    }
                }
                double.TryParse(t, out x1);
            }
            double.TryParse(TxbS1x2.Text, out x2);
            double.TryParse(TxbS2x1.Text, out x3);
            double.TryParse(TxbS2x2.Text, out x4);

            TxbResult1.Text = $"Сумма теней = {ExpressionCalculator.Calculate(x1, x2, x3, x4)}";
        }

        private void Txb_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key < Key.D0 || e.Key > Key.D9) && e.Key != Key.OemMinus)
            {
                e.Handled = true;
            }
        }

        private void TxbA_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key <= Key.D0 || e.Key >= Key.D9) && e.Key != Key.OemMinus)
            {
                e.Handled = true;
            }
            if (e.Key >= Key.A && e.Key <= Key.Z)
                e.Handled = false;
        }
    }
}
