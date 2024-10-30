using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLanguageFeatures.Version10
{
    public class ConstantInterpolatedStrings
    {

        const int TheAnswer = 42;
        // THIS WILL NOT COMPILE, BECAUSE STRING INTERPOLATIONS FOR CONSTANTS ONLY WORK WITH STRINGS.
        /*const string MagicConstant = $"The answer to all questions you ever will ask is {TheAnswer}";*/

        const string MostLovedMeal = "Lasagne";
        const string FullProductName = $"The meal I love the most is {MostLovedMeal}";

    }
}
