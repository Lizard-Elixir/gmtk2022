using System;
using UnityEngine;
namespace UnityAtoms
{
    /// <summary>
    /// IPair of type `&lt;ActionType&gt;`. Inherits from `IPair&lt;ActionType&gt;`.
    /// </summary>
    [Serializable]
    public struct ActionTypePair : IPair<ActionType>
    {
        public ActionType Item1 { get => _item1; set => _item1 = value; }
        public ActionType Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private ActionType _item1;
        [SerializeField]
        private ActionType _item2;

        public void Deconstruct(out ActionType item1, out ActionType item2) { item1 = Item1; item2 = Item2; }
    }
}