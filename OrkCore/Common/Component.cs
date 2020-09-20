using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    /// <summary>
    /// Abstract implementation of a component.
    /// </summary>
    public abstract class Component : IComponent
    {
        #region Public Properties
        /// <inheritdoc/>
        public GameObject GameObject { get; internal set; }

        /// <inheritdoc/>
        public Transform Transform => GameObject; // Since GameObject already inherits from Transform.
        #endregion

        #region Events
        /// <summary>
        /// Gets called after the GameObject goes out of context.
        /// </summary>
        protected internal virtual void OnDestroy() { }

        /// <summary>
        /// Gets called on every fixed update cycle.
        /// </summary>
        protected internal virtual void OnFixedUpdate() { }

        /// <summary>
        /// Gets called after first attaching the script to the GameObject.
        /// </summary>
        protected internal virtual void OnStart() { }

        /// <summary>
        /// Gets called after every update, before rendering.
        /// </summary>
        /// <param name="deltaTime">Time elapsed since the last call to update.</param>
        protected internal void OnUpdate(double deltaTime) { }
        #endregion
    }
}
