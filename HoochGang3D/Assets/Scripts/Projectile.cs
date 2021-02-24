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
            Debug.Log("human death sound");
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

        //find the direction that the target is in
        Vector3 dir = Vector3.Normalize(transform.position - targetPos);

        if(name == "GoblinProjectile(Clone)")
        {
            int forwardZAngle = 208;
            int backZAngle = 25;
            int leftZAngle = 280;
            int rightZAngle = 95;
            int isoUpZAngle = 150;
            int isoDownZAngle = 333;
            int isoLeftZAngle = 241;
            int isRightZAngle = 60;
        }
        else if(name == "AdventurerProjectile(Clone)")
        {
            int forwardZAngle = 208;
            int backZAngle = 29;
            int leftZAngle = 334;
            int rightZAngle = 155;
            int isoUpZAngle = 267;
            int isoDownZAngle = 87;
            int isoLeftZAngle = 357;
            int isRightZAngle = 177;
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
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+208));
        }
        else if(Vector3.Dot(dir, Vector3.back) > 0.8) //up + left
        {
            //set rotation of projectile in Z axis to 25
            //Debug.Log("Rotated Z axis to 25 degrees");
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+25));
        }
        else if(Vector3.Dot(dir, Vector3.left) > 0.8) //up + right
        {
            //set rotation of projectile in Z axis to 280
            //Debug.Log("Rotated Z axis to 280 degrees");
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+280));
        }
        else if(Vector3.Dot(dir, Vector3.right) > 0.8) //down + left
        {
            //set rotation of projectile in Z axis to 95
            //Debug.Log("Rotated Z axis to 95 degrees");
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+95));
        }
        else if(Vector3.Dot(dir, isometricUp) > 0.9)
        {
            //set rotation of projectile in Z axis to 150
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+150));
        }
        else if(Vector3.Dot(dir, isometricDown) > 0.9)
        {
            //set rotation of projectile in Z axis to 333
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+333));
        }
        else if(Vector3.Dot(dir, isometricLeft) > 0.9)
        {
            //set rotation of projectile in Z axis to 241
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+241));
        }
        else if(Vector3.Dot(dir, isometricRight) > 0.9)
        {
            //set rotation of projectile in Z axis to 60
            spriteTransform.Rotate(new Vector3(0, 0, -spriteTransform.rotation.eulerAngles.z+60));
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