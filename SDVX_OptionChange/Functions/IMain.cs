using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SDVX_OptionChange.Functions
{
    interface IMain
    {

        DataTable NavigatorDataSource { get;  set; }
        int NavigatorSelect { get; set; }
        bool AllStageSafe { get; set; }
        bool PremFree { get; set; }
        
    }
}
