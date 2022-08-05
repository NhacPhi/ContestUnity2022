using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PopupEndFGame : MonoBehaviour
{
    [SerializeField]
    private GameObject imgWin;

    [SerializeField]
    private GameObject imgInforGame;

    private Canvas canvas;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClosePopupEndGame()
    {
        canvas.gameObject.SetActive(false);
        SceneManager.LoadScene(Define.MAIN_MENU);
        GameManager.Instance.currentState = GameState.WAITING;
    }

    public void ShopPopupWinGame()
    {
        imgWin.SetActive(true);

        StartCoroutine(TimingToShowInforGame());
    }
    IEnumerator TimingToShowInforGame()
    {
        yield return new WaitForSeconds(3);

        imgInforGame.SetActive(true);
    }
}
