using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public AbilityUI abilityUI;
    public GameObject actionsUI;
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
            actionsUI.gameObject.SetActive(true);
        }
        else
        {
            abilityUI.gameObject.SetActive(false);
            actionsUI.gameObject.SetActive(false);
        }
    }
}
