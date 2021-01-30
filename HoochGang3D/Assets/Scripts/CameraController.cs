using UnityEngine;
public class CameraController : MonoBehaviour
{
    //private bool doMovement = true;
    public float panSpeed = 30f;
    //public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minZoom = 10f;
    public float maxZoom = 30f;
    private Camera thisCamera;

    void Start()
    {
        thisCamera = GetComponent<Camera>();
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
}
