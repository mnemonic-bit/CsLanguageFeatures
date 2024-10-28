namespace CsLanguageFeatures.Version11;

public class GenericAttributes
{
       // C# 11:

       [NewGenericAttributeWay<string>()]
       public string Method2() => default;
       
       
       // C# 10 and older:
       
       [OldAttributeWay(typeof(string))]
       public string Method1() => default;
       
}

public class NewGenericAttributeWayAttribute<T> : Attribute
{
}

public class OldAttributeWayAttribute : Attribute
{
       public OldAttributeWayAttribute(Type type)
       {
              // throw new NotImplementedException();
       }
}



