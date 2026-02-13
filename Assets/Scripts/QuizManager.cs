using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private List<Question> questions;
    [SerializeField] private List<Button> buttons;
    [SerializeField] private GameObject panelPlayerPrefab;
    [SerializeField] private GameObject panelPlayers;
	[SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelQuiz;
	[SerializeField] private CanvasGroup fadeOverlay;

	private int nbPlayers;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
			int index = i;
			buttons[i].onClick.AddListener(() => onButtonClicked(index)); //=> allow params (called 'lambda function')
			//buttons[i].onClick.AddListener(OnStartButtonClicked); => does not allow params
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void onButtonClicked(int index)
    {
        nbPlayers = index + 2;
        Debug.Log("nbPlayers : " + nbPlayers);
        panelMenu.SetActive(false);
        for (int i = 0; i < nbPlayers; i++)
        {
            GameObject child = GameObject.Instantiate(panelPlayerPrefab);
            child.transform.SetParent(panelPlayers.transform, false);
        }
		panelQuiz.SetActive(true);
	}
}
