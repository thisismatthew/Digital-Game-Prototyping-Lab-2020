using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Goblin : MonoBehaviour
{
    public GameObject agentUI;
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gm.currentCharacter == this.gameObject)
        {
            agentUI.SetActive(true);
            return;
        }

        agentUI.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!gm.currentCharacter.CompareTag(gameObject.tag))
        {
            return;
        }

        gm.currentCharacter = this.gameObject;
    }
}
