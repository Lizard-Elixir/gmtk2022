#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;

namespace UnityAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `ActionType`. Inherits from `AtomEventEditor&lt;ActionType, ActionTypeEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(ActionTypeEvent))]
    public sealed class ActionTypeEventEditor : AtomEventEditor<ActionType, ActionTypeEvent> { }
}
#endif
