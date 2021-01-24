using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public AbilityUI abilityUI;
    public AmbushUI ambushUI;
    private TurnManager tm;

    private void Start()
    {
        tm = GameObject.Find("GameManager").GetComponent<TurnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tm.currentCharacter.CompareTag("Goblin"))
        {
            abilityUI.gameObject.SetActive(true);
            ambushUI.gameObject.SetActive(false);
        }
        else
        {
            abilityUI.gameObject.SetActive(false);
            ambushUI.gameObject.SetActive(true);
        }
    }
}
