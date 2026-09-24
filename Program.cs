using System;
using System.Globalization;

namespace ConsoleBank
{
    internal class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            double Summa, PercentBank, BonusInDay, BonusInPeriod;
            int Period;
            string Temp;

            //NumberFormatInfo customFormat = new NumberFormatInfo();
            //customFormat.CurrencySymbol = "В рублях "; // Меняем обозначение
            //customFormat.CurrencySymbol = "₽"; // Меняем обозначение
            //customFormat.NumberGroupSeparator = " "; // Пробел как разделитель групп
            //customFormat.NumberDecimalSeparator = ":";

            Console.Write("Введите сумму вклада ->");
            Temp = Console.ReadLine();
            Summa = Convert.ToDouble(Temp);

            Console.Write("Введите срок вклада ->");
            Temp = Console.ReadLine();
            Period = Convert.ToInt32(Temp);

            PercentBank = 5.25 + rand.NextDouble() * 11.61;
            Console.WriteLine("Ваш назначенный банковский % = {0:N2}", PercentBank);

            BonusInDay = PercentBank / (100 * 365) * Summa;
            Console.WriteLine("Ваш ежедневный доход = " + BonusInDay.ToString("N2") + " в рублях");
            //Console.WriteLine("Ваш ежедневный доход = " + BonusInDay.ToString("C2", customFormat));
            BonusInPeriod = BonusInDay * Period;
            Console.WriteLine($"Ваш доход за период = {BonusInPeriod:N2} в рублях");

            Summa += BonusInPeriod;
            Console.WriteLine($"Ваша сумма на счету в конце периода вклада = {Summa:N2} в рублях");

            Console.ReadKey();
        }
    }
}
