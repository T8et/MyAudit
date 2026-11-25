using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
    public class SrvcCodeGenerator
    {
        public string UserCodeGenerator(string key)
        {
            string code = "USR" + DateTime.Now.ToString("yyMM") + key.Substring(0, 3).ToUpper();
            return code;
        }

        public string TranCodeGenerator(string key)
        {
            string code = "TRX" + DateTime.Now.ToString("yyMM") + key.Substring(0, 3).ToUpper();
            return code;
        }
    }
}
