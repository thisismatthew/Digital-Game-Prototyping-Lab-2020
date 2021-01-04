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
        if (IsNodeTaken() != null)
        {
            gm.currentCharacter = IsNodeTaken();
            return;
        }

<<<<<<< HEAD
        gm.currentCharacter.GetComponent<Movement>().SetDest(this.gameObject.transform);
=======
        gm.currentCharacter.GetComponent<Movement>().goal = this.gameObject.transform;
>>>>>>> main
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

    private GameObject IsNodeTaken()
    {
        foreach (GameObject c in gm.characters)
        {
            if (Vector3.Distance(c.transform.position, this.gameObject.transform.position) < 3.0f)
            {
                return c;
            }
        }

        return null;
    }
}
