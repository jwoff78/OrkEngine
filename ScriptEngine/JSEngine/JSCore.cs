using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jint;
using Jint.Parser;
namespace ScriptEngine.JSEngine
{
    public class JSCore
    {
        public Engine jsEngine = new Engine();

        public void DoString(string script)
        {
            jsEngine.Execute(script);
        }

        public void DoString(string script, ParserOptions options)
        {
            jsEngine.Execute(script, options);
        }

        public void DoFile(string fileName)
        {

        }

        public void DoFiles(string[] files)
        {
            
        }

        [Obsolete("Don't fucking use", true)]
        public void ThinkScript(string script, bool fish)
        {

        }
    }
}
