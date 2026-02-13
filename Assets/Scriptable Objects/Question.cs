using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Scriptable Objects/Question")]
public class Question : ScriptableObject
{
    [SerializeField] private string title;
	[SerializeField] private bool hasAnswers; 
	[SerializeField] private List<string> answers;
	[SerializeField] private string goodAnswer;
}
