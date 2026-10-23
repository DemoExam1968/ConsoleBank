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
            double summa, percentBank, bonusInDay, bonusInPeriod, bonusMonth;
            int period;
            int countMonths;
            string temp;

            Console.Title = "Банковская задача";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            //Блок ввода даннных
            Console.Write("Введите сумму вклада ->");
            temp = Console.ReadLine();
            summa = Convert.ToDouble(temp);

            //Валидация ввода срока
            do
            {
                Console.Write("Введите срок вклада ->");
                temp = Console.ReadLine();
                period = Convert.ToInt32(temp);
                if (period != 91 && period != 181 && period != 365)
                {
                    Console.WriteLine("Вы ошиблись со сроком. Повторите еще раз");
                }
            } while (period != 91 && period != 181 && period != 365);

            //Выбор банковского % в засимости от срока
            percentBank = 0;
            switch (period)
            {
                case 91:percentBank = BANKTHREEMONTH; break;
                case 181:percentBank = BANKSIXMONTH; break;
                case 365:percentBank = BANKYEAR; break;
            }

            Console.CursorLeft = 10;
            Console.WriteLine("Ваш назначенный банковский % = {0:N2}", percentBank);

            //Расчетный блок
            countMonths = period / 30;  //Кол-во месяцев строка
            bonusInPeriod = 0;          //Общий доход за весь период
            for (int month = 1; month <= countMonths; month++)
            {
                bonusMonth = percentBank / 100/ 12 * summa;     //Надбавка за один месяц
                summa = summa + bonusMonth;            //Увеличивающаяся сумма на счету
                bonusInPeriod += bonusMonth;
                Console.WriteLine($"Ваш ежемесячный доход в {month} месяц = " + bonusMonth.ToString("N2") + " в рублях"); //На экран
                Console.WriteLine($"Ваша сумма на счету в {month} месяц = " + summa.ToString("N2") + " в рублях");//На экран
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            //Результат

            Console.WriteLine($"Ваша общая банковская надбавка за весь период = {bonusInPeriod:N2} в рублях");
            Console.WriteLine($"Ваша сумма на счету в конце периода вклада = {summa:N2} в рублях");

            Console.ReadKey();
        }
    }
}
