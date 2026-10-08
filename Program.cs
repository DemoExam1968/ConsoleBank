/*
Банковская задача
Входные
Выходные
 */

using System;

namespace ConsoleBank
{
    internal class Program
    {
        const double BANKTHREEMONTH = 11.50;    //3 месяца
        const double BANKSIXMONTH = 11.75;    //6 месяцев
        const double BANKYEAR = 12.50;    //год

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Блок объявления локальных велчин
            double summa, percentBank, bonusInDay, bonusInPeriod;
            int period;
            string temp;

            Console.Title = "Банковская задача";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            //Блок ввода даннных
            Console.SetCursorPosition(10, 10);
            Console.Write("Введите сумму вклада ->");
            temp = Console.ReadLine();
            summa = Convert.ToDouble(temp);
            //Валидация ввода срока
            rep:  Console.CursorLeft = 10;
            Console.Write("Введите срок вклада ->");
            temp = Console.ReadLine();
            period = Convert.ToInt32(temp);
            if (period != 91 && period!=181 && period != 365)
            {
                Console.WriteLine("Вы ошиблись со сроком. Повторите еще раз");
                goto rep;
            }

            //Выбор банковского % в засимости от срока
            if (period == 91)
            {
                percentBank = BANKTHREEMONTH;
            }
            else
            {
                if (period == 181)
                {
                    percentBank = BANKSIXMONTH;
                }
                else
                {
                    percentBank = BANKYEAR;
                }

            }

            Console.CursorLeft = 10;
            Console.WriteLine("Ваш назначенный банковский % = {0:N2}", percentBank);

            //Расчетный блок
            bonusInDay = percentBank / (100 * 365) * summa;
            Console.CursorLeft = 10;
            Console.WriteLine("Ваш ежедневный доход = " + bonusInDay.ToString("N2") + " в рублях");
            bonusInPeriod = bonusInDay * period;
            Console.CursorLeft = 10;
            Console.WriteLine($"Ваш доход за период = {bonusInPeriod:N2} в рублях");
            summa += bonusInPeriod;

            Console.ForegroundColor = ConsoleColor.Yellow;
            //Результат
            Console.CursorLeft = 10;
            Console.WriteLine($"Ваша сумма на счету в конце периода вклада = {summa:N2} в рублях");

            Console.ReadKey();
        }
    }
}
