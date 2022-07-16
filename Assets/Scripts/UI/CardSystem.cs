using System.Collections;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CardSystem : MonoBehaviour {

	[Header("Settings")]
	[SerializeField]
	private float fadeDuration;
	[SerializeField]
	private AnimationCurve fadeCurve;
	[SerializeField]
	private Card testNarrativeCard;

	[Header("References")]
	[SerializeField]
	private TextMeshProUGUI text;
	[SerializeField]
	private TextMeshProUGUI continuePrompt;

	private Canvas canvas;

	private bool continueSequence;

	private void Awake() {
		canvas = GetComponent<Canvas>();
	}

	[Button]
	private void TestNarrativeCard() => ShowCardSequence(testNarrativeCard);

	public void ShowCardSequence(Card narrativeCard) {
		StartCoroutine(StartSequence(narrativeCard));
	}

	private IEnumerator StartSequence(Card narrativeCard) {
		// show
		canvas.enabled = true;

		for (int i = 0; i < narrativeCard.text.Length; i++) {
			yield return null;
			continuePrompt.enabled = false;

			text.text = narrativeCard.text[i];

			yield return new WaitForSeconds(1);
			continuePrompt.enabled = true;
			yield return new WaitUntil(() => continueSequence);
		}

		canvas.enabled = false;
	}

}