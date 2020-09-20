using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkEngine
{
    /// <summary>
    /// Contains the most basic information used by a single component.
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Gets the parent GameObject that this script is attached to.
        /// </summary>
        GameObject GameObject { get; }

        /// <summary>
        /// Gets the transform attached to the current GameObject.
        /// </summary>
        Transform Transform { get; }

        // TODO: Add other public methods for Component.
    }
}
