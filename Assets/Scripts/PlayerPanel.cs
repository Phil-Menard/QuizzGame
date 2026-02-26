using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
	[SerializeField] private Button minus;
	[SerializeField] private Button plus;
	[SerializeField] private TextMeshProUGUI score;
	[SerializeField] private TMP_InputField answerInput;
	[SerializeField] private TextMeshProUGUI pseudo;
	public void ClearAnswer() => answerInput.SetTextWithoutNotify("");

	private int scoreInt;

	void Start()
	{
		minus.onClick.AddListener(() => RemovePoint());
		plus.onClick.AddListener(() => AddPoint());
		scoreInt = 0;
	}

	private void RemovePoint()
	{
		scoreInt--;
		score.text = scoreInt.ToString();
	}

	private void AddPoint()
	{
		scoreInt++;
		score.text = scoreInt.ToString();
	}
}
