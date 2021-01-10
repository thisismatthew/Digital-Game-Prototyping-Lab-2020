using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Vector3 positionOffset;
    private SpriteRenderer rend;
    private Sprite startSprite;
    public Sprite hoverSprite;

    [SerializeField] private GameManager gm;
    private void Start()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
        startSprite = rend.sprite;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (IsNodeTaken() != null)
        {
            gm.SelectCharacter(IsNodeTaken());
            return;
        }

        gm.currentCharacter.GetComponent<Movement>().SetDest(this.transform.position);
        gm.NextCharacter();
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        rend.sprite = hoverSprite;
    }

    void OnMouseExit()
    {
        rend.sprite = startSprite;
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
