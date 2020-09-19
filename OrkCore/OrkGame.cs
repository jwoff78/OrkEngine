using OpenTK;
using OpenTK.Input;
using OrkEngine.Graphics;
using OrkEngine.Graphics.Common;
using System;
using System.Collections.Generic;

namespace OrkEngine
{
    /// <summary>
    /// Represents a game.
    /// Contains a set of properties and functions used to run a game.
    /// </summary>
    public class OrkGame : IDisposable
    {
        #region Fields
        private Window m_window;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets a list with all the game objects in the game.
        /// </summary>
        public IReadOnlyList<GameObject> Objects => m_window.Objects;

        /// <summary>
        /// Gets the main camera.
        /// </summary>
        public GameObject Camera { get; private set; }
        #endregion

        #region Helpers
        /// <summary>
        /// Does a bunch of checks to make sure the whole engine is here, and also checks file health.
        /// </summary>
        private void SignatureCheck() { }
        #endregion

        #region Game Events
        /// <summary>
        /// Gets called when the core libraries are loaded.
        /// </summary>
        protected virtual void OnLoad() { }

        /// <summary>
        /// Gets called before the game starts.
        /// </summary>
        protected virtual void OnStart() { }

        /// <summary>
        /// Gets called on every call to Update().
        /// </summary>
        protected virtual void OnUpdate(double deltaTime) { }

        /// <summary>
        /// Gets called on every call to FixedUpdate().
        /// </summary>
        protected virtual void OnFixedUpdate() { }

        /// <summary>
        /// Gets called if a late update occurs.
        /// </summary>
        protected virtual void OnLateUpdate() { }

        /// <summary>
        /// Gets called if Disable() is called.
        /// </summary>
        protected virtual void OnDisable() { }

        /// <summary>
        /// Gets called after every update on render.
        /// </summary>
        protected virtual void OnRender() { }
        #endregion

        #region Game Functions
        /// <summary>
        /// Starts the game.
        /// </summary>
        public void Start() => m_window.Run(60.0);

        public void Stop() => m_window.Exit();

        /// <summary>
        /// Disables the current game window.
        /// </summary>
        public void Disable()
        {
            // TODO: Force disabled status in the instance.
            OnDisable();
        }
        #endregion

        #region Other Logic
        public void AddObject(GameObject gameObject)
        {
            if (gameObject is object)
                m_window.AddToRenderQueue(gameObject);
        }

        public bool KeyDown(Key key) => Keyboard.GetState().IsKeyDown(key);
        #endregion

        #region Implementation of IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dumping)
        {
            if (dumping) Dump();
        }

        /// <summary>
        /// Deletes all of the object holders.
        /// </summary>
        private void Dump()
        {

        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of the OrkGame class with all the default values.
        /// </summary>
        public OrkGame() : this("Made with OrkGame") { }

        /// <summary>
        /// Creates a new instance of the OrkGame class with a custom title and default size.
        /// </summary>
        /// <param name="title">Title of this window.</param>
        public OrkGame(string title) : this(title, 1024, 768) { }

        /// <summary>
        /// Creates a new instance of the OrkGame class with custom window properties.
        /// </summary>
        /// <param name="title">Title of this window.</param>
        /// <param name="width">Width of this window.</param>
        /// <param name="height">Height of this window.</param>
        public OrkGame(string title, int width, int height)
        {
            SignatureCheck();
            Camera = GameObject.Camera(width / (float)height);
            m_window = new Window(title, width, height, Camera)
            {
                OnStart = OnStart,
                OnUpdate = OnUpdate
            };
            // TODO: Initialize more stuff.
        }
        #endregion
    }
}