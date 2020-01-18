using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public enum Kuzov { Sedan, Universal, Kupe}
    class Engine
    {
        int EnginePower;
        double FuelConsumption;
        public Engine(int power, double consumption)
        {
            EnginePower = power;
            FuelConsumption = consumption;
        }
        public void Show()
        {
            Console.WriteLine("Мощность двигателя " + EnginePower + " л.с.");
            Console.WriteLine("Расход топлива " + FuelConsumption + "л. на 100км");
        }
    }
    class Automobile
    {
        private static Automobile instance;

        public Engine Engine { get; private set; }
        public Kuzov Kuzov { get; private set; }
        public string Factory { get; private set; }

        protected Automobile(Engine eng, Kuzov kuz, string fac)
        {
            this.Engine = eng;
            this.Kuzov = kuz;
            this.Factory = fac;
        }
        public static Automobile getInstance(Engine eng, Kuzov kuz, string fac)
        {
            if (instance == null)
            {
                instance = new Automobile(eng, kuz, fac);                
            }
            return instance;
        }
    }

    class CreatingAuto
    {
        public Automobile Automobile { get; set; }

        public void CreateAutomobile(Engine eng, Kuzov kuz, string fac)
        {
            Automobile = Automobile.getInstance(eng, kuz, fac);
            Automobile.Engine.Show();
            Console.WriteLine(Automobile.Kuzov.ToString(), Automobile.Factory);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создаем Ладу Приору: ");

            CreatingAuto LadaPriora = new CreatingAuto();
            LadaPriora.CreateAutomobile(new Engine(86, 5.6), Kuzov.Sedan, "АЦ Лада");

            Console.WriteLine();
            Console.WriteLine("Пытаемся заменить Приору на Беху: ");
            LadaPriora.CreateAutomobile(new Engine(400, 12.5), Kuzov.Kupe, "АЦ BMW");

            Console.ReadLine();
        }
    }
}
