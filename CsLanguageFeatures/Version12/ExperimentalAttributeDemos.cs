using System.Diagnostics.CodeAnalysis;

namespace CsLanguageFeatures.Version12;

public class ExperimentalAttributeDemos
{

    public void UseDeliberatelyAnExperimentalFeature()
    {
        // WE NEED TO DISABLE OUR OWN EXPERIMENTAL DIAGNOSTICS
        // TO MAKE THIS CODE COMPILE, BECAUSE C# TREATS THIS
        // ATTRIBUTE AS AN ERROR WHEN WE USE THAT METHOD.
#pragma warning disable MyMethod
        MyMethod();
#pragma warning restore MyMethod
    }

    [Experimental(nameof(MyMethod))]
    public void MyMethod()
    {
        // ...
    }

}
