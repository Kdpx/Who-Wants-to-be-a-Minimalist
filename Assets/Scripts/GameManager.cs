using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] ObjectsToSpawn;
    public int numOfObjects = 40;
    public int numOfTagsToFind = 6;
    public bool isDone = false;
    public string[] tagsToCheck;
    private string[] tags = { "Shovel", "Apple", "Banana", "Bandages", "Bat", "Beer", "Book", "Burger", "Briefcase", "Bucket", "Cooler", "Coffee cup", "Drill", "Energy drink", "Handbag", "Knife", "Longboard", "Plunger", "Screwdriver", "Skateboard", "Sportsbag", "Tablet", "Frying pan", "Spatula", "Golf club", "Hammer" };
    public Text[] Boxes;
    public GameObject[] checkBoxes;

    public Countdown cd;
    public float timeLeft = 300.0f;


    // Update is called once per frame
    void Start()
    {
        CreateList();

        AddGoalObjects();

        AddRandomObjects();

        MakeCheckList();

        cd.startTimer(timeLeft);
    }

    private void AddRandomObjects()
    {
        for (int i = 0; i < numOfObjects; i++)
        {
            // Random position within this transform
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
            Quaternion spawnRotation = Quaternion.identity;

            //change 44 depending on the size of the array
            GameObject ObjectToSpawn = ObjectsToSpawn[Random.Range(0, 44)];
            for (int j = 0; j < tagsToCheck.Length; j++)
            {
                if (ObjectToSpawn.gameObject.CompareTag(tagsToCheck[j]))
                {
                    ObjectToSpawn = ObjectsToSpawn[Random.Range(0, 44)];
                }
            }

            Instantiate(ObjectToSpawn, rndPosWithin, spawnRotation);
        }
    }

    private void AddGoalObjects()
    {
        for(int i = 0; i < numOfTagsToFind; i++)
        {
            foreach (GameObject prefab in ObjectsToSpawn)
            {
                if (prefab.CompareTag(tagsToCheck[i]))
                {
                    // Random position within this transform
                    Vector3 rndPosWithin;
                    rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                    rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
                    Quaternion spawnRotation = Quaternion.identity;

                    Instantiate(prefab, rndPosWithin, spawnRotation);
                    break;
                }
            }
        }
    }

    private void CreateList()
    {
        tagsToCheck = new string[numOfTagsToFind];
        for (int i = 0; i < numOfTagsToFind; i++)
        {
            string tagToAdd = tags[Random.Range(0, tags.Length)];
            foreach (string tag in tagsToCheck)
            {
                if (tag == tagToAdd)
                {
                    tagToAdd = tags[Random.Range(0, tags.Length)];
                }
            }
            tagsToCheck[i] = tagToAdd;
        }
    }

    private void MakeCheckList()
    {
        for (int i = 0; i < numOfTagsToFind; i++)
        {
            //Debug.Log(i);
            //Debug.Log(tagsToCheck[i]);
            Boxes[i].GetComponent<Text>().text = tagsToCheck[i];
            //Add i th element of tagToCheck to i th element of boxes' text field
        }
    }
}