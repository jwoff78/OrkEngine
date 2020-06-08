using NLua;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptEngine.LuaEngine
{
    class LuaCore
    {
    }

    public class LuaCoreExtensions
    {
        //m_WorkingDirectory
        private static string WorkingDirectory;

        public static string WorkingDir
        {
            get
            {
                return WorkingDirectory;
            }
            set
            {
                WorkingDirectory = value;
            }
        }

        public static List<string> LoadedFiles = new List<string>();
        public static Queue<string> LoadLater = new Queue<string>();

        public static Dictionary<string, object> Config = new Dictionary<string, object>();

        public static object GetObjectVar(Lua lua, string type)
        {
            object temp = lua[type];

            return temp;
        }

        public static void SetVar(Lua lua, string VarName, object Value)
        {
            lua[VarName] = Value;
        }

        public static LuaFunction MethodCall(Lua lua, string func)
        {
            LuaFunction LuaFunc = lua[func] as LuaFunction;
            
            return LuaFunc;
        }

        public static void LoadLuaFile(Lua lua, string fileName)
        {
            if (File.Exists(fileName))
            {
                lua.DoFile(fileName);
                LoadedFiles.Add(fileName);
            }
        }

        public static void LoadLuaFiles(Lua lua, string[] files, bool LoadNow)
        {
            //Check if files are available
            List<string> RealFiles = new List<string>();

            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    RealFiles.Add(file);
                }
            }

            //Load Files now or add them to a 'load later' list
            if (LoadNow)
            {
                foreach (string file in RealFiles)
                {
                    lua.DoFile(file);
                    LoadedFiles.Add(file);
                }
            }
            else
            {
                foreach (string file in RealFiles)
                    LoadLater.Enqueue(file);
            }
        }

        public static void LoadSavedFiles(Lua lua)
        {
            while (LoadLater.Count > 0)
            {
                string file = LoadLater.Dequeue();
                if (File.Exists(file))
                {
                    lua.DoFile(file);
                }
            }
        }

        public static void LoadLuaConfig(Lua lua, string Path)
        {
            Lua localLua = new Lua();
            localLua.DoFile(Path);

            //Get Standard Params
            Config.Add("EngineVersion", GetObjectVar(localLua, "EngineVersion"));
            Config.Add("ScriptOwner", GetObjectVar(localLua, "ScriptOwner"));

            //Files
            LuaTable LT = localLua["Files"] as LuaTable;
            List<string> filesToLoad = new List<string>();

            foreach (var v in LT.Values)
            {
                filesToLoad.Add((string)v);
            }

            LoadLuaFiles(lua, filesToLoad.ToArray(), true);

            //Optional Params
            LT = localLua["Params"] as LuaTable;
            Queue<string> Rules = new Queue<string>();

            foreach (var v in LT.Values)
            {
                Rules.Enqueue((string)v);
            }

            while (Rules.Count > 0)
            {
                string Rule = Rules.Dequeue();
                string[] parts = Rule.Split(':');

                if (parts.Length == 1)
                {
                    Config.Add(parts[0], localLua[parts[0]]);
                }
                else
                {
                    LT = localLua[parts[0]] as LuaTable;
                    Dictionary<object, object> TableContent = new Dictionary<object, object>();
                    List<object> keys = new List<object>();
                    List<object> values = new List<object>();
                    foreach (var v in LT.Keys) keys.Add(v);
                    foreach (var v in LT.Values) values.Add(v);
                    for (int i = 0; i < keys.Count; i++) { TableContent.Add(keys[i], values[i]); }

                    if (TableContent.ContainsKey(parts[1]))
                    {
                        Config.Add(parts[1], TableContent[parts[1]]);
                    }
                }
            }

            // This code is just for displaying the config and making it look pretty
            
            /*List<object> key = new List<object>(Config.Keys);
            List<object> val = new List<object>(Config.Values);
            Console.WriteLine("Loaded Config.");
            Console.WriteLine("--------------------------------------");
            for (int i = 0; i < key.Count; i++)
            {
                string keyout = (string)key[i];
                int missing = 20 - keyout.Length;
                string s = "";
                for (int j = 0; j < missing; j++) { s += " ";}
                keyout += s;

                Console.WriteLine(keyout + " : " + val[i]);
            }*/
        }

        public static void GetWorkingDirectiory(string directory)
        {
            WorkingDirectory = directory;
        }

        public static void GetMainMethod(Lua lua)
        {
            MethodCall(lua, "JarCore");
            //start
            //onupdate
            //ondisable
            //etc
        }
    }
}
