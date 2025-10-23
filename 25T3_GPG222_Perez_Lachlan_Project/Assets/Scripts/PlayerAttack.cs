using Unity.Netcode;
using UnityEngine;

public class PlayerAttack : NetworkBehaviour
{
    [SerializeField] private float weaponHitRadius;
    [SerializeField] private Transform weaponHitPoint;
    [SerializeField] private int damage = 2;
    [SerializeField] private GameObject hitEffect;

    [SerializeField] private LayerMask targetLayer;

    [SerializeField] private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            animator.SetTrigger("attack");
        }
    }

    public void DetectHit()
    {
        Collider[] hit = Physics.OverlapSphere(weaponHitPoint.position, weaponHitRadius, targetLayer);

        if(hit.Length > 0)
        {
            hit[0].GetComponent<Health>().TakeDamage(damage);
            Instantiate(hitEffect.transform, hit[0].transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(weaponHitPoint.position, weaponHitRadius);
    }
}
