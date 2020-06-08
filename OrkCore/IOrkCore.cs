using System;

namespace OrkCore
{
    public class IOrkCore : IDisposable
    {
        /// <summary>
        /// Calls all of the private methods for an initilization.
        /// </summary>
        public IOrkCore()
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
}