using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanel : MonoBehaviour
{
    [SerializeField] private Button minus;
    [SerializeField] private Button plus;
    [SerializeField] private TextMeshProUGUI score;
    private int scoreInt;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
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
