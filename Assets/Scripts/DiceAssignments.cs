[System.Serializable]
public class DiceAssignments {

	private ActionType[] dice = new [] { ActionType.Magic, ActionType.Defense, ActionType.Attack };

	private ActionType D4 => dice[0];
	private ActionType D6 => dice[1];
	private ActionType D8 => dice[2];

	public DiceAssignments(ActionType d4Action, ActionType d6Action, ActionType d8Action) {
		Initialize(d4Action, d6Action, d8Action);
	}

	public void Initialize(ActionType d4Action, ActionType d6Action, ActionType d8Action) {
		dice[0] = d4Action;
		dice[1] = d6Action;
		dice[2] = d8Action;
	}

	public void SwitchMagicAndDefense() => SwitchTypes(ActionType.Magic, ActionType.Defense);
	public void SwitchMagicAndAttack() => SwitchTypes(ActionType.Magic, ActionType.Attack);
	public void SwitchAttackAndDefense() => SwitchTypes(ActionType.Attack, ActionType.Defense);

	private void SwitchTypes(ActionType type1, ActionType type2) {
		int index1 = 0;
		int index2 = 0;

		for (int i = 0; i < dice.Length; i++) {
			if (dice[i] == type1)
				index1 = i;
			else if (dice[i] == type2)
				index2 = i;
		}

		(dice[index1], dice[index2]) = (dice[index2], dice[index1]);
	}

	private bool IsValid() => (
		(int)D4 + (int)D6 + (int)D8 == 6 && // to make sure none are None
		D4 != D6 && D4 != D8 && D6 != D8 // to make sure they're all unique
	);
}