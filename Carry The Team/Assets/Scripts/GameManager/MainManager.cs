using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    // 

    // the lives of each player
    private int P1Lives, P2Lives, P3Lives, P4Lives;

    public MinigameSetup scenes;

    bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    void Start ()
	{
        P1Lives = 4;
        P2Lives = 4;
        P3Lives = 4;
        P4Lives = 4;



        scenes.AddMinigames();
        scenes.QueueMinigames();
	}
	
    void StartNextMinigame()
    {
        SceneManager.LoadScene(scenes.GetNextMinigame());
    }

	void Update ()
	{
        if(Input.GetKeyDown(KeyCode.L))
        {
            StartNextMinigame();
        }
	}
}
