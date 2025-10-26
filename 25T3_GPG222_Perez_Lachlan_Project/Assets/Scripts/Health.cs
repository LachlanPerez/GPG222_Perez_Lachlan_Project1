using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int attack;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<Health>();
        if(atm != null)
        {
            atm.TakeDamage(attack);
        }
    }
}
