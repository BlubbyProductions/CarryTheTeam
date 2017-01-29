using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinigameSetup : MonoBehaviour
{

    ArrayList names = new ArrayList(); // list of all minigames
    ArrayList queue = new ArrayList(); // order of minigames each match
    int next = 0;
    bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    public string GetNextMinigame()
    {
        string temp = "";

        if (next >= queue.Count)
        {
            next = 0;
        }

        temp = queue[next].ToString();
        next++;

        return temp;
    }

    public void AddMinigames()
    {
        names.Add("Greenlight Go");
        names.Add("Climb the Pole");
    }

    public void QueueMinigames()
    {
        while(names.Count != 0)
        {
            int index = Random.Range(0, names.Count);
            queue.Add(names[index]);
            names.RemoveAt(index);
        }

        for(int i = 0; i < queue.Count; i++)
        {
            Debug.Log(queue[i].ToString());
        }
    }



	void Start ()
    {
        //TestQueue();
    }

    void TestQueue()
    {
        names.Add("Greenlight Go");
        names.Add("Climb the Pole");
        names.Add("Chicken Fight");
        names.Add("Fiesta Party");
        names.Add("Ice Climbers");
        names.Add("Water Trouble");
        names.Add("Something Fishy");
        QueueMinigames();
    }
}
