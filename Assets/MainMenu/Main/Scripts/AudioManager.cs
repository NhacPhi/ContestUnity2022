using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { set; get; }
    [SerializeField]
    private AudioSource miniGame;

    [SerializeField]
    private AudioSource mainMenu;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMusicMiniGame()
    {
        mainMenu.Stop();
        miniGame.Play();
    }
}
