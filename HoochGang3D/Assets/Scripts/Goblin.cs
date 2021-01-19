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
        gm.ResetAllNodes();
    }
}
