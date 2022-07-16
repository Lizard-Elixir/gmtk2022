using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatBar : MonoBehaviour {

	[SerializeField]
	private Color colour;
	[SerializeField]
	private int sizePerValue;

	[SerializeField]
	private IntVariable currentValue;
	[SerializeField]
	private IntVariable maxValue;
	[SerializeField]
	private Image fillImage;
	[SerializeField]
	private TextMeshProUGUI valueText;
	[SerializeField]
	private Button diceAssignButton;
	[SerializeField]
	private Button executeActionButton;

	private RectTransform rt;

	private void Awake() {
		rt = GetComponent<RectTransform>();

		fillImage.color = colour;
		valueText.color = colour;
		currentValue.Changed.Register(UpdateValue);
		maxValue.Changed.Register(UpdateValue);
		UpdateValue();
		DisableAssignDice();
	}

	public void EnableAssignDice() {
		diceAssignButton.gameObject.SetActive(true);
	}

	public void DisableAssignDice() {
		diceAssignButton.gameObject.SetActive(false);
	}

	public void ShowStatExecution(CharacterAction action) {
		executeActionButton.gameObject.SetActive(true);
		executeActionButton.GetComponent<TextMeshProUGUI>().text = action.name;
	}

	public void DisableExecuteStat() {
		executeActionButton.gameObject.SetActive(false);
	}

	private void OnDestroy() {
		currentValue.Changed.Unregister(UpdateValue);
		maxValue.Changed.Unregister(UpdateValue);
	}

	private void UpdateValue() {
		rt.sizeDelta = new Vector2(sizePerValue * maxValue.Value, rt.sizeDelta.y);
		fillImage.fillAmount = (float)currentValue.Value / maxValue.Value;
		valueText.text = $"{currentValue.Value}/{maxValue.Value}";
	}
}