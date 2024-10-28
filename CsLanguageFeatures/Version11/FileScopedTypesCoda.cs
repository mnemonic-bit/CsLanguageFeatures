using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsLanguageFeatures.Version11
{
    public class FileScopedTypesCoda
    {

        [Fact]
        public void Test()
        {
            // This will not compile because the type we are using is
            // file-scoped, which means we cannot "see" it in code which
            // is stored in another file than that file where the used
            // class is defined and stored.
            /*var fileScopedType = new ThisClassCanOnlyBeSeenFromCodeWithinThisFile();*/
        }

    }
}
