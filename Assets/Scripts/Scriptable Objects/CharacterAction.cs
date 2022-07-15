using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Action")]
public class CharacterAction : ScriptableObject {

	public enum ActionType {
		Magic,
		Defense,
		Attack
	}

	public new string name;
	public ActionType type;
	[MinValue(0)]
	public int value;

}