using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public enum GameQuests
    {
        saveTheChild = 0,
        slayTheHamster = 1,
        findTheTreasure = 2,
        defeatTheOrg = 3
    }

    public enum Status
    {
        unavailable = 0,
        assigned = 1,
        inProgress = 2,
        completed = 3
    }

    // public int saveTheChild = 0; not needed if we set it up in the enum above
    // public int slayTheHamster = 1;
    // public int findTheTreasure = 2;
    // public int defeatTheOrg = 3;

    public List<Status> quests = new List<Status>();

    //matt would use a dictionary for this regularly instead of a list

    public void AddQuest(int quest)
    {
        quests[quest] = Status.assigned;
    }

    // public void AddQuest(GameQuests quest)
    // {
    //     quests[(int)quest] = Status.assigned;
    // }

    public void CompleteQuest(int quest)
    {
        quests[quest] = Status.completed;    
    }

    void Start()
    {
        for(int i = 0; i < (int)GameQuests.defeatTheOrg; i ++){
            quests.Insert(i, Status.unavailable);
            //moving through all the quests and setting them all to unavailable
        }
    }

    public void Update()
    {
        for(int i = 0; i < (int)GameQuests.defeatTheOrg; i ++){
            Debug.Log(quests[i] + ": " + (GameQuests)i);
        }
    }

}
