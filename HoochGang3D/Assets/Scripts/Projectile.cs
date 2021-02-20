using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;

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
        if (gameObject.tag == "Adventurer")
            gameObject.GetComponentInChildren<Animator>().Play("Adventurer_death");
        else
            gameObject.GetComponentInChildren<Animator>().Play("Goblin_death");

        Destroy(gameObject, 3f);
    }
    
    void Damage(Transform enemy)
    {
        if (enemy.gameObject.tag == "Adventurer")
            enemy.gameObject.GetComponentInChildren<Animator>().Play("Adventurer_death");
        else
            enemy.gameObject.GetComponentInChildren<Animator>().Play("Goblin_death");
        Destroy(enemy.gameObject, 3f);
    }
}
