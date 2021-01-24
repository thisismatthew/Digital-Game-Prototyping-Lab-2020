using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Goblin : Character
{
    public GameObject agentUI;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        if (tm.currentCharacter == this.gameObject)
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
        if (!tm.currentCharacter.CompareTag(gameObject.tag))
        {
            return;
        }

        tm.currentCharacter = this.gameObject;
        nm.ResetAllNodes();
    }
}
