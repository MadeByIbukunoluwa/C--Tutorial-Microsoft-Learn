using System.Reflection;

namespace attributes1;

//var attr = new ObsoleteAttribute("some string")
[Obsolete("This class is obsolete, Use ThisClass2 instead.")]
public class MyClass
{

}
public class ThisClass2
{

}
public class MySpecialAttribute : Attribute
{

}


[MySpecial] public class SomeOtherClass
{

}




public class GotchaAttribute : Attribute
{
    // cant create attributes with parameters of certain types 
    //public GotchaAttribute(Foo myClass, string str)
    //{

    //}
}


//[Gotcha(new myClass(),"test")]


public class AttributeFail
{

}


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class MyAttributeForClassAndStructOnly : Attribute
{

}

public class Foo
{
    //[MyAttributeForClassAndStructOnly]
    // If uncommented, it will cause an error saying Attribute "MyAttributeForClassAndStructOnly"
    // is not valid on 'class' , 'struct' declarations
    //if we change the code below by putting class in front of the public , the error will go, because thetype is valid for the attribute
    public Foo()
    {

    }
}

public class Program
{ 
    public static void Main(string[] args)
    {
        TypeInfo typeInfo = typeof(ThisClass2).GetTypeInfo();
        Console.WriteLine("The assembly qualified name of MyClass is" + typeInfo.AssemblyQualifiedName);
    }
}