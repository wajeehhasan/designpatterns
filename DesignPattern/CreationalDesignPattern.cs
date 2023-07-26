using System;
namespace CreationalDesignPattern
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

    #region BuilderDesign
    //1 - create a parent class, attributes and method to access those attributes
    //2 - create abstract class with methods to set parent class attributes for multiple implementation-
        //- and method to create, return and an object of parent class. this abstract is called builder class
    //3 - implement a concreate class, there can be multiple concreate classes with their own definition.
    //4 -  create a director class which uses builder class to build the object and return it as a complete object.

    public class ParentClass
    {
        public string PropName { get; set; }
        public string PropType { get; set; }

        public void PropertyDisplay()
        {
            Console.WriteLine("Name : " + PropName + ", Type : " + PropType);
        }
    }
    public abstract class BuilderClass
    {
        protected ParentClass parentObj;
        public abstract void SetPropName();
        public abstract void SetPropType();

        public void CreateParentObj()
        {
            parentObj = new ParentClass();
        }
        public ParentClass GetParentObj()
        {
            return parentObj;
        }
    }
    public class ConcreteClassA : BuilderClass
    {
        public override void SetPropName()
        {
            parentObj.PropName = "Name A";
        }
        public override void SetPropType()
        {
            parentObj.PropType = "Type A";
        }
    }
    public class ConcreteClassB : BuilderClass
    {
        public override void SetPropName()
        {
            parentObj.PropName = "Name B";
        }
        public override void SetPropType()
        {
            parentObj.PropType = "Type B";
        }
    }
    public class Directorclass
    {
        public ParentClass MakeParentObject(BuilderClass BuilderObj)
        {
            BuilderObj.CreateParentObj();
            BuilderObj.SetPropName();
            BuilderObj.SetPropType();
            return BuilderObj.GetParentObj();
        }
    }
    #endregion BuilderDesign

    #region FluentDesign
    public class FluentDesign
    {
 
        public int id { get; set; }
        public string PropA { get; set; }
        public string PropB { get; set; }

        public FluentDesign SetId(int id)
        {
            this.id = id;
            return this;
        }
        public FluentDesign SetPropA(string prop)
        {
            this.PropA = prop;
            return this;
        }
        public FluentDesign SetPropB(string prop)
        {
            this.PropB = prop;
            return this;
        }
    }
    #endregion FluentDesign

    #region FactoryMethodDesign
    public interface BaseInterface
    {
        string propA();
    }

    public class ConcreteA : BaseInterface
    {
        public string propA()
        {
            return "Property A";
        }
    }
    public class ConcreteB : BaseInterface
    {
        public string propA()
        {
            return "Property B";
        }
    }
    public abstract class BaseIntFactory
    {
        protected abstract BaseInterface MakeInterfaceObj();

        public BaseInterface CreateInterface()
        {
            BaseInterface interfaceObj = this.MakeInterfaceObj();
            return interfaceObj;
        }
    }
    public class ConcreteAFactory : BaseIntFactory
    {
        protected override BaseInterface MakeInterfaceObj()
        {
            BaseInterface product = new ConcreteA();
            return product;
        }
    }
    public class ConcreteBFactory : BaseIntFactory
    {
        protected override BaseInterface MakeInterfaceObj()
        {
            BaseInterface product = new ConcreteB();
            return product;
        }
    }
    #endregion FactoryMethodDesign
}

namespace CreationalDesignPattern
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
            #region BuilderDesign
            Directorclass directorclass = new Directorclass();
            ConcreteClassA concreteClassA = new ConcreteClassA();
            ConcreteClassB concreteClassB = new ConcreteClassB();
            ParentClass parentClassA = directorclass.MakeParentObject(concreteClassA);
            ParentClass parentClassB = directorclass.MakeParentObject(concreteClassB);
            parentClassA.PropertyDisplay();
            Console.WriteLine("--------------------------");
            parentClassB.PropertyDisplay();
            #endregion BuilderDesign
            #region FluentDesign
            FluentDesign FluentObj = new FluentDesign();
            FluentObj.SetId(1).SetPropA("Wajeeh").SetPropB("Hasan");

            Console.WriteLine(FluentObj.PropA + " " + FluentObj.PropB);


            #endregion FluentDesign

            #region FactoryMethodDesign
            BaseInterface interfaceObj = new ConcreteBFactory().CreateInterface();
            Console.WriteLine(interfaceObj.propA());
            #endregion FactoryMethodDesign
        }
    }
}
