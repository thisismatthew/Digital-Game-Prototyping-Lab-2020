using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Goblin : Character
{
    public GameObject agentUI;
    public MeshRenderer _meshRenderer;
    private Material goblinMaterial;
    public Material stealthGoblinMaterial;
    private string startingTag;

    //private bool hidden; //if true, the unit is stealthed

    protected override void Start()
    {
        base.Start();
        //goblinMaterial = _meshRenderer.material;
        startingTag = gameObject.tag;
        actionsLeft = 2;
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
        if (actionsLeft <= 0) //if this character can still take actions
        {
            return;
        }
        tm.currentCharacter = this.gameObject;
        nm.ResetAllNodes();
    }

    public void GoIntoStealth()
    {
        _meshRenderer.material = stealthGoblinMaterial;
        _meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        //gameObject.tag = "Goblin Hiding"; //set to a tag that will still count as a goblin from the manager
    }

    public void Reveal()
    {
        _meshRenderer.material = goblinMaterial;
        _meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        gameObject.tag = startingTag;
    }
}
