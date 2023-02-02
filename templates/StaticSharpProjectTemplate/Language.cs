using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticSharpProjectTemplate
{
    public enum Language
    {
        En
#if multilanguage
            ,Ru
#endif
    }
}
