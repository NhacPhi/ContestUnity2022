using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TipGame : MonoBehaviour
{
    [SerializeField]
    private Canvas popUpShowTip;


    public void ShowTipGame()
    {
        popUpShowTip.gameObject.SetActive(true);
    }
    public void ExitTip()
    {
        popUpShowTip.gameObject.SetActive(false);
    }
}
