using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
	[SerializeField] private List<Question> questions;
	[SerializeField] private List<Button> nbPlayersButtons;
	[SerializeField] private Button previousQuestion;
	[SerializeField] private Button nextQuestion;
	[SerializeField] private TextMeshProUGUI question;
	[SerializeField] private List<Image> answerPanels;
	[SerializeField] private List<TextMeshProUGUI> answers;
	[SerializeField] private GameObject panelPlayerPrefab;
	[SerializeField] private GameObject panelMenu;
	[SerializeField] private GameObject panelTop;
	[SerializeField] private GameObject panelAnswers;
	[SerializeField] private GameObject panelQuiz;
	[SerializeField] private GameObject goodAnswer;
	[SerializeField] private TextMeshProUGUI goodAnswerText;
	[SerializeField] private GameObject showAnswer;
	[SerializeField] private Button showAnswerButton;
	[SerializeField] private GameObject startQuizz;
	[SerializeField] private Button startQuizzButton;
	[SerializeField] private GameObject panelPlayers;
	[SerializeField] private CanvasGroup fadeOverlay;

	private int indexQuestions;
	private int nbPlayers;
	private Color32 greenColor;
	private Color32 redColor;
	private Color32 whiteColor;

	private void Awake()
	{
		panelMenu.SetActive(true);
		panelQuiz.SetActive(false);
		indexQuestions = 0;
		greenColor = new Color32(180, 200, 191, 255);
		redColor = new Color32(202, 165, 186, 255);
		whiteColor = new Color32(242, 234, 222, 255);
	}

	void Start()
	{
		for (int i = 0; i < nbPlayersButtons.Count; i++)
		{
			int index = i;
			nbPlayersButtons[i].onClick.AddListener(() => SetupPlayers(index)); //=> allow params (called 'lambda function')
			//nbPlayersButtons[i].onClick.AddListener(SetupPlayers); => does not allow params
		}
		showAnswerButton.onClick.AddListener(() => ShowAnswer(indexQuestions));
		startQuizzButton.onClick.AddListener(StartQuizz);
		nextQuestion.onClick.AddListener(NextQuestion);
	}

	private void SetupPlayers(int index)
	{
		nbPlayers = index + 2;
		panelMenu.SetActive(false);
		for (int i = 0; i < nbPlayers; i++)
		{
			GameObject child = Instantiate(panelPlayerPrefab);
			child.transform.SetParent(panelPlayers.transform, false);
		}
		panelQuiz.SetActive(true);
	}

	private void StartQuizz()
	{
		startQuizz.SetActive(false);
		showAnswer.SetActive(true);
		panelTop.SetActive(true);
		ShowQuestion(indexQuestions);
	}

	private void ShowQuestion(int index)
	{
		Question actualQuestion = questions[index];
		question.text = actualQuestion.question;

		if (actualQuestion.hasAnswers)
		{
			for (int i = 0; i < 4; i++)
			{
				answerPanels[i].color = whiteColor;
				answers[i].text = actualQuestion.answers[i];
			}
			panelAnswers.SetActive(true);
		}
		else
			panelAnswers.SetActive(false);
	}

	private void ShowAnswer(int index)
	{
		Question actualQuestion = questions[index];
		if (actualQuestion.hasAnswers)
		{
			for (int i = 0; i < 4; i++)
			{
				if (actualQuestion.answers[i] == actualQuestion.goodAnswer)
					answerPanels[i].color = greenColor;
				else
					answerPanels[i].color = redColor;
			}
		}
		else
		{
			goodAnswer.SetActive(true);
			showAnswer.SetActive(false);
			goodAnswerText.text = actualQuestion.goodAnswer;
		}
	}

	private void NextQuestion()
	{
		indexQuestions++;
		goodAnswer.SetActive(false);
		showAnswer.SetActive(true);
		if (indexQuestions < questions.Count)
			ShowQuestion(indexQuestions);
	}
}
