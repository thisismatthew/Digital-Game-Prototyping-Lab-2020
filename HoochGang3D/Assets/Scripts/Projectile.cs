using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    public void Seek(Transform _target)
    {
        target = _target;
        //PointAtTarget(target.transform.position);
    }

    void Update()
    {
        //transform.rotation = Quaternion.identity;

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
        //transform.LookAt(target);
    }

    void HitTarget()
    {
        Damage(target);
        Destroy(gameObject, 3f);
    }
    
    void Damage(Transform enemy)
    {
        if (enemy.gameObject.CompareTag("Adventurer"))
            enemy.gameObject.GetComponentInChildren<Animator>().Play("Adventurer_death");
        else
            enemy.gameObject.GetComponentInChildren<Animator>().Play("Goblin_death");
        Destroy(enemy.gameObject, 3f);
    }

    private void PointAtTarget(Vector3 targetPos)
    {
        //Get the transform of the child sprite
        Quaternion spriteRotation = GetComponentInChildren<Transform>().rotation;
        Vector3 debugForward = Vector3.forward;

        //find the direction that the target is in
        Vector3 dir = Vector3.Normalize(transform.position - targetPos);

        if(dir.normalized.Equals(Vector3.forward)) //up + left
        {
            //set rotation of projectile in Z axis to 25
            spriteRotation.eulerAngles = new Vector3(spriteRotation.x, spriteRotation.y, 25);
        }
        else if(dir.normalized.Equals(Vector3.back)) //down + right
        {
            //set rotation of projectile in Z axis to 208
            spriteRotation.eulerAngles = new Vector3(spriteRotation.x, spriteRotation.y, 208);
        }
        else if(dir.normalized.Equals(Vector3.left)) //down + left
        {
            //set rotation of projectile in Z axis to 95
            spriteRotation.eulerAngles = new Vector3(spriteRotation.x, spriteRotation.y, 95);
        }
        else if(dir.normalized.Equals(Vector3.right)) //up + right
        {
            //set rotation of projectile in Z axis to 280
            spriteRotation.eulerAngles = new Vector3(spriteRotation.x, spriteRotation.y, 280);
        }
        else
        {
            Debug.Log("Projectile is pointing in direction: " + dir.ToString() + ". This is not properly handled.");
            Debug.Log(Vector3.forward.ToString());
        }
    }
}
