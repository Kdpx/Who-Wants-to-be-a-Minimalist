using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public GameManager gm;
    public LevelLoader ll;
    public Countdown cd;
    private bool[] conditions;

    private void Start()
    {
        if(gm.numOfTagsToFind == 6)
        {
            conditions = new bool[] { false, false, false, false, false, false };
        }
        else
        {
            conditions = new bool[] { false, false, false, false, false, false, false, false, false, false };
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        bool found = false;

        foreach(string tag in gm.tagsToCheck)
        {
            if (other.gameObject.CompareTag(tag))
            {
                for (int i = 0; i < gm.numOfTagsToFind; i++)
                {
                    if (tag == gm.tagsToCheck[i])
                    {
                        conditions[i] = true;
                        found = true;
                        gm.checkBoxes[i].SetActive(true);
                    }
                }
                other.GetComponent<Drag>().Disable();
            }
        }

        if (!found)
        {
            Penalize();
        }
    }

    private void Update()
    {
        ll.isDone = IsAllMissionComplete();
    }

    private bool IsAllMissionComplete()
    {
        for (int i = 0; i < conditions.Length; ++i)
        {
            if (!conditions[i])
            {
                return false;
            }
        }
        
        return true;
    }

    private void Penalize()
    {
        cd.timeLeft -= 5.0f;
    }
}
