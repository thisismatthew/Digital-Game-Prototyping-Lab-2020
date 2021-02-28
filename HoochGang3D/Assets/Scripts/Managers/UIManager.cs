using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public AbilityUI abilityUI;
    public GameObject actionsUI;
    private TurnManager tm;
    public GameObject[] playerUI;
    public Text enemyIndicator;
    public Text waveCounter;
    private int numOfEnemies;

    private void Start()
    {
        tm = GameObject.Find("GameManager").GetComponent<TurnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        numOfEnemies = tm.adventurers.Count;
        enemyIndicator.text = numOfEnemies.ToString();

        waveCounter.text = tm.wm.currentWaveIndex.ToString() + "/" + tm.wm.waves.Length.ToString();

        if (tm.GetComponent<GameManager>().gameIsOver)
        {
            return;
        }

        if (tm.currentCharacter.CompareTag("Goblin"))
        {
            foreach(GameObject g in playerUI)
            {
                g.SetActive(true);
            }
            //abilityUI.gameObject.SetActive(true);
            //actionsUI.gameObject.SetActive(true);
        }
        else
        {
            foreach(GameObject g in playerUI)
            {
                g.SetActive(false);
            }
            //abilityUI.gameObject.SetActive(false);
            //actionsUI.gameObject.SetActive(false);
        } 
    }
}
