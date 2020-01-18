using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    abstract class Kuzov
    {
        public abstract void Show();
    }
    class Universal : Kuzov
    {
        public override void Show()
        {
            Console.WriteLine("Универсальный кузов");
        }
    }
    class Sedan : Kuzov
    {
        public override void Show()
        {
            Console.WriteLine("Седан-кузов");
        }
    }
    class Kupe : Kuzov
    {
        public override void Show()
        {
            Console.WriteLine("Купе-кузов");
        }
    }
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
            Console.WriteLine("Мощность двигателя "+ EnginePower + " л.с.");
            Console.WriteLine("Расход топлива "+ FuelConsumption + "л. на 100км");
        }
    }
    abstract class AutoFactory
    {
        public abstract Kuzov CreateCuzov();
        public abstract Engine CreateEngine(int power, double consumption);
    }
    class LadaFactory : AutoFactory
    {
        public override Kuzov CreateCuzov()
        {
            return new Sedan();
        }

        public override Engine CreateEngine(int power, double consumption)
        {
            return new Engine(power, consumption);
        }
    }
    class AudiFactory : AutoFactory
    {
        public override Kuzov CreateCuzov()
        {
            return new Universal();
        }

        public override Engine CreateEngine(int power, double consumption)
        {
            return new Engine(power, consumption);
        }
    }
    class BMWFactory : AutoFactory
    {
        public override Kuzov CreateCuzov()
        {
            return new Kupe();
        }

        public override Engine CreateEngine(int power, double consumption)
        {
            return new Engine(power, consumption);
        }
    }
    //Client - автомобиль
    class Automobile
    {
        private Engine engine;
        private Kuzov kuzov;
        //private string factory;
        public Automobile(AutoFactory factory, int p, double c)
        {
            engine = factory.CreateEngine(p, c);
            kuzov = factory.CreateCuzov();
        }
        public void ShowInfo()
        {
            engine.Show();
            kuzov.Show();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создаем Ладу Приору: ");
            Automobile Lada_Priora = new Automobile(new LadaFactory(), 86, 5.6);
            Lada_Priora.ShowInfo();

            Console.WriteLine();

            Console.WriteLine("Создаем БМВ Х6: ");
            Automobile BMW_X6 = new Automobile(new BMWFactory(), 400, 12.5);
            BMW_X6.ShowInfo();

            Console.ReadLine();
        }
    }
}
