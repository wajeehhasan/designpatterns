using System;
namespace SingletonDemo
{
    //public sealed class Singleton
    //{
    //    //This variable value will be increment by 1 each time the object of the class is created
    //    private static int Counter = 0;
    //    //This variable is going to store the Singleton Instance
    //    private static Singleton Instance = null;
    //    //The following Static Method is going to return the Singleton Instance
    //    public static Singleton GetInstance()
    //    {
    //        //If the variable instance is null, then create the Singleton instance 
    //        //else return the already created singleton instance
    //        //This version is not thread safe
    //        if (Instance == null)
    //        {
    //            Instance = new Singleton();
    //        }
    //        //Return the Singleton Instance
    //        return Instance;
    //    }
    //    //Constructor is Private means, from outside the class we cannot create an instance of this class
    //    private Singleton()
    //    {
    //        //Each Time the Constructor called, increment the Counter value by 1
    //        Counter++;
    //        Console.WriteLine("Counter Value " + Counter.ToString());
    //    }
    //    //The following can be accesed from outside of the class by using the Singleton Instance
    //    public void PrintDetails(string message)
    //    {
    //        Console.WriteLine(message);
    //    }
    //}
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
            if(ObjCcounter==0)
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
}

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
         
            Singleton instanceA = Singleton.GetInstance();

            Singleton instanceB = Singleton.GetInstance();

        }
    }
}