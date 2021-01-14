using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmbushUI : MonoBehaviour
{
    public Text enemyCount;
    public Button ambushBtn;
    private int count;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        ambushBtn.interactable = false;
    }

    private void Update()
    {
        count = 0;

        foreach (GameObject c in gm.characters)
        {
            if (c.CompareTag("Adventurer"))
            {
                if (c.GetComponent<CharacterStatus>().Detected)
                {
                    count++;
                }
            }
        }

        enemyCount.text = count.ToString();
    }
}
