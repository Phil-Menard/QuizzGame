using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Scriptable Objects/Question")]
public class Question : ScriptableObject
{
	[SerializeField] public string question;
	[SerializeField] public bool hasImage;
	[SerializeField] public bool hasAnswers;
	[SerializeField] public List<string> answers;
	[SerializeField] public string goodAnswer;
}
