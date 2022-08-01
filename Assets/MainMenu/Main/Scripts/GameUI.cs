using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour
{
    public static GameUI Instance;

    [SerializeField]
    private Canvas popUpMenuGame;

   
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameMenu()
    {

    }
    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void ShowPopUpMenuAndPauseGame()
    {
        popUpMenuGame.gameObject.SetActive(true);
    }
    public void ExitPopUp()
    {
        popUpMenuGame.gameObject.SetActive(false) ;
    }
}
