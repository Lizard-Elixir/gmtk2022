using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Character")]
public class Character : ScriptableObject {

	public new string name;
	public int maxHealth = 100;

    [HideInInspector]
	public int modToHealth;

	[NameElements]
	public ActionData[] magicActions;
	[NameElements]
	public ActionData[] defenseActions;
	[NameElements]
	public ActionData[] attackActions;

	public ActionData GetMagicAction(int magicValue) => GetActionAtValue(magicActions, magicValue);
	public ActionData GetDefenseAction(int defenseValue) => GetActionAtValue(defenseActions, defenseValue);
	public ActionData GetAttackAction(int attackValue) => GetActionAtValue(attackActions, attackValue);

	private ActionData GetActionAtValue(ActionData[] data, int value) {
		for (int i = 0; i < data.Length; i++) {
			if (value < data[i].width) {
				return data[i];
			} else {
				value -= data[i].width;
			}
		}

		return new ActionData();
	}

	[System.Serializable]
	public class ActionData : INameableElement {
		public CharacterAction action;
		[Range(0, 1)]
		public float bias;
		[MinValue(1)]
		public int width;

		public string GetArrayElementName(int index) {
			return action?.name ?? "No action";
		}
	}
}