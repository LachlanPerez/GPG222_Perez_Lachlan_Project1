using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    private PlayerAttack playerAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
    }

    private void Attack()
    {
        playerAttack.DetectHit();
    }
}
