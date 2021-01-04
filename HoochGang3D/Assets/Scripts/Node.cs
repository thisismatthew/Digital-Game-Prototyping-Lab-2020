using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Vector3 positionOffset;
    private Renderer rend;
    private Material startMaterial;
    public Material hoverMaterial;

    [SerializeField] private GameManager gm;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startMaterial = rend.material;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        gm.currentCharacter.GetComponent<Movement>().SetDest(this.gameObject.transform);
        gm.NextCharacter();
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        rend.material = hoverMaterial;
    }

    void OnMouseExit()
    {
        rend.material = startMaterial;
    }
}
