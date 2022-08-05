using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseGame : MonoBehaviour
{
    [SerializeField]
    private Canvas popupPauseGame;

    [SerializeField]
    private GameObject imgPlay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPauseGame()
    {
        popupPauseGame.gameObject.SetActive(true);
        Time.timeScale = 0;
        imgPlay.SetActive(true);
    }
    public void HidePauseGame()
    {
        popupPauseGame.gameObject.SetActive(false);
        Time.timeScale = 1;
        imgPlay.SetActive(false);
    }
    public void ShowGameMenu()
    {
        Debug.Log("Game Menu");
        GameManager.Instance.currentState = GameState.WAITING;
        SceneManager.LoadScene(Define.MAIN_MENU);
    }
}
