using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public AbilityUI abilityUI;
    public AmbushUI ambushUI;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.currentCharacter.CompareTag("Goblin"))
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
