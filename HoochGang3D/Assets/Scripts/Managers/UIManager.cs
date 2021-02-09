using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public AbilityUI abilityUI;
    public GameObject actionsUI;
    private TurnManager tm;
    public GameObject[] playerUI;

    private void Start()
    {
        tm = GameObject.Find("GameManager").GetComponent<TurnManager>();
    }

    // Update is called once per frame
    void Update()
    {
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
