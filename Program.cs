using System;
namespace _2
{
    class Program
    {
        static void Main()
        {
            Bankomat bankomat = new Bankomat(cash: 1000, id: 78921, 5000, 100);

            while (true)
            {
                Console.WriteLine("Нажмите 0, чтобы внести деньги или 1, чтобы снять");
                int answer = int.Parse(Console.ReadLine());
                if (answer == 0)
                {
                    Console.WriteLine(bankomat);
                    Console.WriteLine("Внесите деньги: ");
                    int sumIn = int.Parse(Console.ReadLine());
                    var serverAnswer = ProcessControl(bankomat, sumIn, answer);

                }
                else if (answer == 1)
                {
                    Console.WriteLine(bankomat);
                    Console.WriteLine("Введите снимаемую сумму: ");
                    int sumOut = int.Parse(Console.ReadLine());
                    var serverAnswer = ProcessControl(bankomat, sumOut, answer);

                }
                else
                {
                    Console.WriteLine("Неизвестная операция, попробуйте заново.");
                }

            }

        }
        public static int ProcessControl(Bankomat bankomat, int someSumm, int method)
        {
            bool valid = Valid(someSumm, bankomat);

            if (!valid) return 404;
            
            if (method == 0)
            {
                var result = bankomat + someSumm;
                Console.WriteLine(bankomat);
                return 100;
            }
            else if (method == 1)
            {
                if (someSumm > bankomat.Cash)
                {
                    Console.WriteLine("В банкомате недостаточно средств!");
                    Console.WriteLine(bankomat);
                    return 404;
                }
                var result = bankomat - someSumm;
                Console.WriteLine(bankomat);
                return 100;

            }
            Console.WriteLine("Что-то пошло не так неизвестная команда");
            return 404;

        }

    
        public static bool Valid(int someSumm, Bankomat bankomat)
        {
            if (someSumm % 10 != 0)
            {
                Console.WriteLine("Вносимая сумма должна быть кратна 10.");
                return false;
            }
            if (someSumm < bankomat.Min || someSumm > bankomat.Max)
            {
                Console.WriteLine("Вносимая сумма не соответствует мин. и макс. параметрку");
                return false;
            }
            return true;
        }
        }

}

