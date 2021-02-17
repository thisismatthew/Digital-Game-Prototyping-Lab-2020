using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour
{
    //private bool doMovement = true;
    public float panSpeed = 30f;
    //public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minZoom = 10f;
    public float maxZoom = 50f;
    public Camera thisCamera;
    private Vector3 positionToCentreOn;
    private bool centred = true;
    public int centreSpeed = 9;
    public bool dontMoveCamera = false;
    private float startingOrthographicSize;
    private bool unfocused;
    public int unfocusedCameraSize = 50;
    public int zoomSpeed = 5;
    //public float timer = 0; //delay for zooming out and changing the camera during enemy turns
    private Vector3 worldCentre;

    private void Start()
    {
        thisCamera = this.gameObject.GetComponentInChildren<Camera>();
        startingOrthographicSize = thisCamera.orthographicSize;
        unfocused = !centred;
        worldCentre = new Vector3(60f,0f,60f);
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

        if(positionToCentreOn != null && Vector3.Distance(transform.position, positionToCentreOn) <= 1) //if the distances are within 0.5 units of eachother and it isn't null
        {
            centred = true;
        }

        /*if(unfocused == false && thisCamera.orthographicSize >= unfocusedCameraSize)
        {
            unfocused = true;
        }*/
    }

    private void FixedUpdate()
    {
        /*timer -= Time.deltaTime;

        if(timer < 0)
        {
            if(!centred && positionToCentreOn != null)
            {
                //move towards the character we want to centre on, the two lines below have a similar behaviour
                //transform.Translate((placeToCentreOn.position - transform.position) * panSpeed / centreSpeed  * Time.deltaTime, Space.World);
                transform.position = Vector3.Lerp(positionToCentreOn, transform.position, 0.5f);
            }
        }
        else if(!unfocused && thisCamera.orthographicSize < unfocusedCameraSize)
        {
            Debug.Log("Current place to centre on: " + positionToCentreOn.ToString());
            thisCamera.orthographicSize += zoomSpeed;
            transform.position = Vector3.Lerp(positionToCentreOn, transform.position, 0.5f);
        }*/
        
        if(!centred && positionToCentreOn != null)
        {
            //move towards the character we want to centre on, the two lines below have a similar behaviour
            transform.Translate((positionToCentreOn - transform.position) * panSpeed / centreSpeed  * Time.deltaTime, Space.World);
            //transform.position = Vector3.Lerp(positionToCentreOn, transform.position, 0.5f);
        }

        if(!unfocused && thisCamera.orthographicSize < unfocusedCameraSize)
        {
            thisCamera.orthographicSize += zoomSpeed;
            //transform.position = Vector3.Lerp(positionToCentreOn, transform.position, 0.5f);
        }
    }

    public void CentreCameraOnTransform(Vector3 pos)
    {
        if(!dontMoveCamera)
        {
            centred = false;
        }
        positionToCentreOn = pos;
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

    public void UnFocus()
    {
        if(!dontMoveCamera)
        {
            unfocused = false;
        }
        CentreCameraOnTransform(worldCentre);
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
