using System;
using UnityEngine.Events;

namespace UnityAtoms
{
    /// <summary>
    /// None generic Unity Event of type `ActionType`. Inherits from `UnityEvent&lt;ActionType&gt;`.
    /// </summary>
    [Serializable]
    public sealed class ActionTypeUnityEvent : UnityEvent<ActionType> { }
}
