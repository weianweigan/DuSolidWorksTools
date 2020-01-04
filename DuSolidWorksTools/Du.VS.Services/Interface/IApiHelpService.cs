using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Du.VS.Services.Interface
{
    public interface IApiHelpService
    {
        void ShowApiHelp();

        void ShowInVS();

        void ShowInBrowser();

        void ShowInToolBox();
    }
}
