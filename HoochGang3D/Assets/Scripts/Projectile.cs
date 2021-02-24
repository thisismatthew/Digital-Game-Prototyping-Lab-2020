using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    [SerializeField] private Transform spriteTransform;
    public void Start()
    {
        FindObjectOfType<AudioManager>().Play("Ranged_Attack");

    }

    public void Seek(Transform _target)
    {
        target = _target;
        PointAtTarget(target.transform.position);
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Damage(target);
        Destroy(gameObject, 3f);
    }
    
    void Damage(Transform enemy)
    {
        if (enemy.gameObject.CompareTag("Adventurer"))
        {
            enemy.gameObject.GetComponentInChildren<Animator>().Play("Adventurer_death");
            FindObjectOfType<AudioManager>().Play("Adventurer_Death_1");
        }
        else
            enemy.gameObject.GetComponentInChildren<Animator>().Play("Goblin_Death_1");
        Destroy(enemy.gameObject, 3f);
    }

    private void PointAtTarget(Vector3 targetPos)
    {
        //define the other vectors we need
        Vector3 isometricUp = new Vector3(1,0,1);
        Vector3 isometricLeft = new Vector3(-1,0,1);
        Vector3 isometricDown = new Vector3(-1,0,-1);
        Vector3 isometricRight = new Vector3(1,0,-1);

        int forwardZAngle = 0;
        int backZAngle = 0;
        int leftZAngle = 0;
        int rightZAngle = 0;
        int isoUpZAngle = 0;
        int isoDownZAngle = 0;
        int isoLeftZAngle = 0;
        int isoRightZAngle = 0;

        //find the direction that the target is in
        Vector3 dir = Vector3.Normalize(transform.position - targetPos);

        if(name == "GoblinProjectile(Clone)")
        {
            forwardZAngle = 208;
            backZAngle = 25;
            leftZAngle = 280;
            rightZAngle = 95;
            isoUpZAngle = 150;
            isoDownZAngle = 333;
            isoLeftZAngle = 241;
            isoRightZAngle = 60;
        }
        else if(name == "AdventurerProjectile(Clone)")
        {
            forwardZAngle = 208;
            backZAngle = 29;
            leftZAngle = 334;
            rightZAngle = 155;
            isoUpZAngle = 87;
            isoDownZAngle = 267;
            isoLeftZAngle = 357;
            isoRightZAngle = 177;
        }
        else
        {
            Debug.Log("Name of projectile needs to be either AdventurerProjectile or GoblinProjectile. Currently is it:" + name.ToString());
        }

        if(Vector3.Dot(dir, Vector3.forward) > 0.8 ) //down + right
        {
            //set rotation of projectile in Z axis to 25
            //Debug.Log("Rotated Z axis to 208 degrees");
            //Debug.Log(spriteTransform.name);
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+forwardZAngle));
        }
        else if(Vector3.Dot(dir, Vector3.back) > 0.8) //up + left
        {
            //set rotation of projectile in Z axis to 25
            //Debug.Log("Rotated Z axis to 25 degrees");
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+backZAngle));
        }
        else if(Vector3.Dot(dir, Vector3.left) > 0.8) //up + right
        {
            //set rotation of projectile in Z axis to 280
            //Debug.Log("Rotated Z axis to 280 degrees");
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+leftZAngle));
        }
        else if(Vector3.Dot(dir, Vector3.right) > 0.8) //down + left
        {
            //set rotation of projectile in Z axis to 95
            //Debug.Log("Rotated Z axis to 95 degrees");
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+rightZAngle));
        }
        else if(Vector3.Dot(dir, isometricUp) > 0.9)
        {
            //set rotation of projectile in Z axis to 150
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+isoUpZAngle));
        }
        else if(Vector3.Dot(dir, isometricDown) > 0.9)
        {
            //set rotation of projectile in Z axis to 333
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+isoDownZAngle));
        }
        else if(Vector3.Dot(dir, isometricLeft) > 0.9)
        {
            //set rotation of projectile in Z axis to 241
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+isoLeftZAngle));
        }
        else if(Vector3.Dot(dir, isometricRight) > 0.9)
        {
            //set rotation of projectile in Z axis to 60
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+isoRightZAngle));
        }
        else
        {
            Debug.Log("Dot product of 4 directions");
            Debug.Log(Vector3.Dot(dir, Vector3.forward).ToString());
            Debug.Log(Vector3.Dot(dir, Vector3.back).ToString());
            Debug.Log(Vector3.Dot(dir, Vector3.left).ToString());
            Debug.Log(Vector3.Dot(dir, Vector3.right).ToString());
            Debug.Log(Vector3.Dot(dir, isometricUp).ToString());
            Debug.Log(Vector3.Dot(dir, isometricDown).ToString());
            Debug.Log(Vector3.Dot(dir, isometricLeft).ToString());
            Debug.Log(Vector3.Dot(dir, isometricRight).ToString());
        }
    }
}