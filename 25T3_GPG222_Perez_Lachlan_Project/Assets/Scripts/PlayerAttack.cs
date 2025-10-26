using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAttack : NetworkBehaviour
{
    [SerializeField] private float weaponHitRadius;
    [SerializeField] private Transform weaponHitPoint;
    [SerializeField] private int damage = 2;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(weaponHitPoint.position, weaponHitRadius);
    }
}
