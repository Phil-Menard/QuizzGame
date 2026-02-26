using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Scriptable Objects/Question")]
public class Question : ScriptableObject
{
	[SerializeField] public string question;
	[SerializeField] public bool hasImage;
	[SerializeField] public Texture2D image;
	[SerializeField] public bool hasAnswers;
	[SerializeField] public List<string> answers;
	[SerializeField] public bool hasSound;
	[SerializeField] public AudioClip audio;
	[SerializeField] public string goodAnswer;
}
