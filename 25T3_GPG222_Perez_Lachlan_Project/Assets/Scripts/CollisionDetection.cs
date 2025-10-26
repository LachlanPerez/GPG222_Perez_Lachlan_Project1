using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public PlayerAttack pa;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && pa.IsAttacking)
        {
            Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("Hit");
        }
    }
}
