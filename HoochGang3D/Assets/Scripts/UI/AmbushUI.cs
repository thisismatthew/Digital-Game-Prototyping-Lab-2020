using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmbushUI : MonoBehaviour
{
    public Text enemyCount;
    public Button ambushBtn;
    public Ambush ambush;
    private GameManager gm;
    private List<List<GameObject>> linesOfSight;
    private List<GameObject> enemiesInSight;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        ambushBtn.interactable = false;
        linesOfSight = new List<List<GameObject>>();
        enemiesInSight = new List<GameObject>();
    }

    private void Update()
    {
        //Get targets in the line of sight of each goblin
        foreach (GameObject c in gm.characters)
        {
            if (c != null)
            {
                if (c.CompareTag("Goblin"))
                {
                    if (c.GetComponent<LineOfSight>().GetTargetsInRange().Count != 0)
                    {
                        linesOfSight.Add(c.GetComponent<LineOfSight>().GetTargetsInRange());
                    }
                }
            }  
        }

        //Discard any repeats
        for (int i = 0; i < linesOfSight.Count; i++)
        {
            CompareLists(linesOfSight[i]);
        }

        //Print that in the UI
        enemyCount.text = enemiesInSight.Count.ToString();

        if (enemiesInSight.Count > 0)
        {
            ambushBtn.interactable = true;
        }
        else
        {
            ambushBtn.interactable = false;
        }

        linesOfSight.Clear();
        enemiesInSight.Clear();
    }

    private void CompareLists(List<GameObject> l1)
    {
        if (enemiesInSight.Count == 0)
        {
            foreach (GameObject t in l1)
            {
                enemiesInSight.Add(t);
            }
        }
        else
        {
            for (int i = 0; i < l1.Count; i++)
            {
                if (!enemiesInSight.Contains(l1[i]))
                {
                    enemiesInSight.Add(l1[i]);
                }
            }
        }
    }

    public void StartAmbush()
    {
        ambush.Execute();
    }
}
