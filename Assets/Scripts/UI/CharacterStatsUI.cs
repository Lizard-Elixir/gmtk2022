using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatsUI : MonoBehaviour {
	[Header("Settings")]
	[SerializeField]
	private float statBoxSize = 24;

	[Header("Atoms")]
	[SerializeField]
	private IntVariable magicVariable;
	[SerializeField]
	private IntVariable maxMagicVariable;
	[SerializeField]
	private IntVariable defenseVariable;
	[SerializeField]
	private IntVariable maxDefenseVariable;
	[SerializeField]
	private IntVariable attackVariable;
	[SerializeField]
	private IntVariable maxAttackVariable;

	[Header("References")]
	[SerializeField]
	private RectTransform magicRT;
	[SerializeField]
	private Image magicFill;
	[SerializeField]
	private RectTransform defenseRT;
	[SerializeField]
	private Image defenseFill;
	[SerializeField]
	private RectTransform attackRT;
	[SerializeField]
	private Image attackFill;

	private void Awake() {
		magicVariable.Changed.Register(OnVariableChanged);
		maxMagicVariable.Changed.Register(OnVariableChanged);
		defenseVariable.Changed.Register(OnVariableChanged);
		maxDefenseVariable.Changed.Register(OnVariableChanged);
		attackVariable.Changed.Register(OnVariableChanged);
		maxAttackVariable.Changed.Register(OnVariableChanged);

		UpdateUI();
	}

	private void OnDestroy() {
		magicVariable.Changed.Unregister(OnVariableChanged);
		maxMagicVariable.Changed.Unregister(OnVariableChanged);
		defenseVariable.Changed.Unregister(OnVariableChanged);
		maxDefenseVariable.Changed.Unregister(OnVariableChanged);
		attackVariable.Changed.Unregister(OnVariableChanged);
		maxAttackVariable.Changed.Unregister(OnVariableChanged);
	}

	private void OnVariableChanged(int _) => UpdateUI();

	public void UpdateUI() {
		magicRT.sizeDelta = new Vector2(statBoxSize * maxMagicVariable.Value, magicRT.sizeDelta.y);
		magicFill.fillAmount = (float)magicVariable.Value / maxMagicVariable.Value;

		defenseRT.sizeDelta = new Vector2(statBoxSize * maxDefenseVariable.Value, defenseRT.sizeDelta.y);
		defenseFill.fillAmount = (float)defenseVariable.Value / maxDefenseVariable.Value;

		attackRT.sizeDelta = new Vector2(statBoxSize * maxAttackVariable.Value, attackRT.sizeDelta.y);
		attackFill.fillAmount = (float)attackVariable.Value / maxAttackVariable.Value;
	}

}