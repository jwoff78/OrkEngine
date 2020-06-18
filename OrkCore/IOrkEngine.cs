using OpenTK;
using OpenTK.Input;
using OrkEngine.Graphics;
using OrkEngine.Graphics.Common;
using System;

namespace OrkEngine
{
    public class IOrkEngine : IDisposable
    {
        private EngineCore engine = new EngineCore();

        /// <summary>
        /// Calls all of the private methods for an initilization.
        /// </summary>
        public IOrkEngine()
        {
            SignatureCheck();
        }

        /// <summary>
        /// Does a bunch of checks to make sure the whole engine is here, and also checks file health.
        /// </summary>
        private void SignatureCheck()
        {
            //bool isTrue = 10 > 5;
        }

        /// <summary>
        /// Run's first thing before anything else is called, OnStart, OnUpdate, Etc...
        /// </summary>
        public void OnLoad()
        {
            engine.Load();
        }

        /// <summary>
        /// The start up function for JarCore
        /// </summary>
        public void OnStart()
        {
            
        }

        public void OnUpdate()
        {
            
        }

        public void OnFixedUpdate()
        {
        }

        public void OnLateUpdate()
        {
        }

        public void OnDisable()
        {
        }

        public void OnRender()
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool dumping)
        {
            if (dumping) Dump();
        }

        /// <summary>
        /// Deletes all of the object holders.
        /// </summary>
        private void Dump()
        {

        }
    }

    internal sealed class EngineCore
    {
        public EngineCore() { /* don't call init */ }

        //moved stuff back to program.cs because this code is supposed to be used by the user
        // - Red

        public void Load()
        {
            
        }
    }
}