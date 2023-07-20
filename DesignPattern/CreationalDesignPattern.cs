using System;
namespace SingletonDemo
{
    #region Singleton
    public sealed class Singleton
    {
        // counter to keep track of the object created of the class
        private static int ObjCcounter = 0;
        //only this instance will be passed whenever object of this class is access
        private static Singleton obj = null;

        //method to get object instance
        public static Singleton GetInstance()
        {
            //check if object already exist if not then create a new and return
            if (ObjCcounter == 0)
            {
                obj = new Singleton();
            }
            return obj;
        }

        // increasing counter value in constructor
        private Singleton()
        {
            ObjCcounter++;
        }

    }
    #endregion Singleton

    #region FactoryDesign
    //interface acting as a blue print for classes to inherit these methods with their own definition
    //it should be used within certain circumstances as in some cases interface segregation is more useful.
    public interface Toyota
    {
        int NumberOfDoors();
        string FuelType();
        string CarType();
    }

    class Camry : Toyota
    {
        public string CarType()
        {
            return "Sedan";
        }

        public string FuelType()
        {
            return "Petrol";
        }

        public int NumberOfDoors()
        {
            return 4;
        }
    }
    class RAV : Toyota
    {
        public string CarType()
        {
            return "SUV";
        }

        public string FuelType()
        {
            return "Hybrid/Petrol";
        }

        public int NumberOfDoors()
        {
            return 4;
        }

    }
    #endregion FactoryDesign
}

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Singleton
            Singleton instanceA = Singleton.GetInstance();

            Singleton instanceB = Singleton.GetInstance();
            #endregion Singleton

            #region Factory
            string cartype = "suv";
            Toyota toyota = null;
            if (cartype == "suv")
            {
                toyota = new RAV();
            }
            else if (cartype == "sedan")
            {
                toyota = new Camry();
            }

            Console.WriteLine(toyota.FuelType());
            #endregion Factory
        }
    }
}