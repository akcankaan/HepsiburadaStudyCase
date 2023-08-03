using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace case1_hepsiburada.Utils
{
    public class GeneralMethods : Helper
    {
        public void GoToUrl(string url) => base.GoToUrl(url);
        public void SwitchToLastWindow(string url) => base.SwitchToLastWindow();
        public void CloseDriver() => base.CloseDriver();
        public string CaptureScreenshot() => base.CaptureScreenshot();
    }
}
