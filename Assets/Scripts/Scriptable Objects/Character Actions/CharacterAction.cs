using NaughtyAttributes;
using UnityEngine;


public abstract class CharacterAction : ScriptableObject {
	public new string name;
	public ActionType type;
	[MinValue(0)]
	public int value;
	public abstract void DoAction();

}