using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NLua;
using ScriptEngine.LuaEngine;
namespace ScriptEngine
{
    class Program
    {
        public static Lua lua = new Lua();
        static void Main(string[] args)
        {
            //<usersfiles> <config.lua>
            //lua.DoString(@"a = 'dis is text';
            //               print(a);");
            //var d = LuaCoreExtensions.GetObjectVar(lua, "y");
            //Console.WriteLine(d);
            //LuaCoreExtensions.MethodCall(lua, "OnStart").Call();
            //LuaCoreExtensions.SetVar(lua, "a", "dis is test nr 2");
            //lua.DoString(@"print(a);");

            /*string[] files = {
                @"C:\Users\User\Documents\GitHub\JarJarGameEngine\ScriptEngine\TestScripts\Test1.lua",
                @"C:\Users\User\Documents\GitHub\JarJarGameEngine\ScriptEngine\TestScripts\Test2.lua",
                @"C:\Users\User\Documents\GitHub\JarJarGameEngine\ScriptEngine\TestScripts\Test3.lua",
                @"C:\Users\User\Documents\GitHub\JarJarGameEngine\ScriptEngine\TestScripts\Test4.lua",
                @"C:\Users\User\Documents\GitHub\JarJarGameEngine\ScriptEngine\TestScripts\Test5.lua"
            };
            //LuaCoreExtensions.LoadLuaFile(lua, @"C:\Users\User\Documents\GitHub\JarJarGameEngine\ScriptEngine\Test.lua");
            LuaCoreExtensions.LoadLuaFiles(lua, files, false);
            LuaCoreExtensions.LoadSavedFiles(lua);*/
            LuaCoreExtensions.LoadLuaConfig(lua, @"C:\Users\User\Documents\GitHub\JarJarGameEngine\ScriptEngine\config.lua");

            Console.ReadLine();
        }

       
    }
}
/*
 *     lua.DoString(@"
	function OnStart ()
		print('Start function loaded.');
	end
	");
            //we will need more LuaCoreExtensions to keep up with easy calls.




            //LuaCoreExtensions luacore = new LuaCoreExtensions();
            LuaCoreExtensions.RegisterMethodCall(lua, "OnStart").Call();
            // var scriptFunc = lua["EmptyF"] as LuaFunction;
            
            //var res = scriptFunc.Call();

            // LuaFunction.Call will also return a array of objects, since a Lua function
            // can return multiple values
            //Console.WriteLine(res);
 * 
 */
