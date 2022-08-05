using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum HearthState
{
    ACTIVE,
    DIEING,
    DEATH
}
public class Health : MonoBehaviour
{
    [SerializeField]
    private Heart heartActive;

    [SerializeField]
    private Heart heartDieing;

    [SerializeField]
    private Heart heartDeath;

    public HearthState currentState;

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = HearthState.ACTIVE;
    }

    private void Update()
    {

    }
    private void OnEnable()
    {
        switch (currentState)
        {
            case HearthState.ACTIVE:
                {
                    heartActive.gameObject.SetActive(true);
                    heartDeath.gameObject.SetActive(false);
                    heartDieing.gameObject.SetActive(false);

                    heartActive.ActiveHeart();
                    heartDeath.DeactiveHeart();
                    heartDieing.DeactiveHeart();
                }
                break;
            case HearthState.DIEING:
                {

                    heartActive.gameObject.SetActive(false);
                    heartDeath.gameObject.SetActive(false);
                    heartDieing.gameObject.SetActive(true);

                    heartActive.DeactiveHeart();
                    heartDeath.DeactiveHeart();
                    heartDieing.ActiveHeart();

                    StartCoroutine(TimingToSwitchState());
                }
                break;
            case HearthState.DEATH:
                {
                    heartActive.gameObject.SetActive(false);
                    heartDeath.gameObject.SetActive(true);
                    heartDieing.gameObject.SetActive(false);

                    heartActive.DeactiveHeart();
                    heartDeath.ActiveHeart();
                    heartDieing.DeactiveHeart();
                }
                break;
        }
    }
    IEnumerator TimingToSwitchState()
    {
        yield return new WaitForSeconds(3f);
        currentState = HearthState.DEATH;
    }

}
