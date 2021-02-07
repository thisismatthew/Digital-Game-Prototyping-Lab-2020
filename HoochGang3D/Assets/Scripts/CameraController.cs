using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour
{
    //private bool doMovement = true;
    public float panSpeed = 30f;
    //public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minZoom = 10f;
    public float maxZoom = 30f;
    public Camera thisCamera;
    private Transform placeToCentreOn;
    private bool centred = true;
    public int centreSpeed = 9;
    public bool debug = false;

    private void Start()
    {
        thisCamera = this.gameObject.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }*/

        /*if(!doMovement)
        {
            return;
        }*/

        if(centred) //if it's the start or we've already centred ourselves on a character
        {
            //recieve user input
            if (Input.GetKey(KeyCode.LeftShift))
            {
                panSpeed = 65f;
            }
            else
            {
                panSpeed = 30f;
            }

            if(Input.GetKey("w"))
            //if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                Vector3 isometricUp = new Vector3(1,0,1); //Forward + Right
                transform.Translate(isometricUp * panSpeed * Time.deltaTime, Space.World);
            }

            if(Input.GetKey("a"))
            //if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            {
                Vector3 isometricLeft = new Vector3(-1,0,1); //Forward + Left
                transform.Translate(isometricLeft * panSpeed * Time.deltaTime, Space.World);
            }

            if(Input.GetKey("s"))
            //if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            {
                Vector3 isometricDown = new Vector3(-1,0,-1); //Back + Left
                transform.Translate(isometricDown * panSpeed * Time.deltaTime, Space.World);
            }
            
            if(Input.GetKey("d"))
            //if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                Vector3 isometricRight = new Vector3(1,0,-1); //Back + Right
                transform.Translate(isometricRight * panSpeed * Time.deltaTime, Space.World);
            }
            
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            thisCamera.orthographicSize -= scroll * 1000 * scrollSpeed * Time.deltaTime;
            thisCamera.orthographicSize = Mathf.Clamp(thisCamera.orthographicSize, minZoom, maxZoom);    
        }

        if(placeToCentreOn != null && Vector3.Distance(transform.position, placeToCentreOn.position) <= 1) //if the distances are within 0.5 units of eachother and it isn't null
        {
            centred = true;
        }    
    }

    private void FixedUpdate()
    {
        if(!centred && placeToCentreOn != null)
        {
            //move towards the character we want to centre on, the two lines below have a similar behaviour
            transform.Translate((placeToCentreOn.position - transform.position) * panSpeed / centreSpeed  * Time.deltaTime, Space.World);
            //transform.position = Vector3.Lerp(placeToCentreOn.position, transform.position, 0.5f);
        }
    }

    public void CentreCameraOnTransform(Transform t)
    {
        if(!debug)
        {
            centred = false;
        }
        placeToCentreOn = t;
        //transform.position = t.position; //set the camera transform the position of the character whose turn it is
        //the above code is really jarring, and it lets the user know there is a unit that can move, but it is not clear what's happening when it changes.
        //In future, I think it would be better to use a cooroutine, see below
        //start a coroutine that translates the camera position to the transform we want to centre on
        //StopCoroutine(Move(t));
        //StartCoroutine(Move(t));
        //Vector3 newVector = t.position - transform.position;
        //Debug.Log(newVector.normalized);
        //transform.Translate(newVector.normalized * panSpeed * Time.deltaTime, Space.World);
        //StartCoroutine(Move(newVector.normalized));
    }

    /*IEnumerator Move(Transform placeToGoTo)
    {
        while(transform.position != placeToGoTo.position)
        {
            transform.Translate((placeToGoTo.position - transform.position) * panSpeed * Time.deltaTime, Space.World);
            yield return new WaitForSeconds(0.01f);
        }

        if(transform.position == placeToGoTo.position)
        {
            Debug.Log("Done");
        }
        //transform.Translate(direction * panSpeed * Time.deltaTime, Space.World);
        //Debug.Log("Running coroutine");
        //yield return new WaitForSeconds(0.5f);
        //Debug.Log("Running coroutine2");
        //StopCoroutine(Move(placeToGoTo));
        yield return null;
    }*/
}
