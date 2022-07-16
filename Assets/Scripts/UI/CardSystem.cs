using System;
using System.Collections;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardSystem : MonoBehaviour {

	public event Action CardSystemStart = delegate {};

	public event Action CardSystemFinished = delegate {};

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
	[SerializeField]
	private Button continueButton;

	private Canvas canvas;

	private void Awake() {
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}

	[Button]
	private void TestNarrativeCard() => ShowCardSequence(testNarrativeCard);

	public void ShowCardSequence(Card narrativeCard) {
		StartCoroutine(StartSequence(narrativeCard));
	}

	private IEnumerator StartSequence(Card narrativeCard) {
		// show
		CardSystemStart?.Invoke();
		canvas.enabled = true;

		for (int i = 0; i < narrativeCard.text.Length; i++) {
			yield return null;
			continuePrompt.enabled = false;

			text.text = narrativeCard.text[i];

			yield return new WaitForSeconds(.5f);
			continuePrompt.enabled = true;
			yield return new WaitUntil(() => UnityEngine.InputSystem.Mouse.current.leftButton.wasPressedThisFrame);
		}

		canvas.enabled = false;
		CardSystemFinished?.Invoke();
	}
}