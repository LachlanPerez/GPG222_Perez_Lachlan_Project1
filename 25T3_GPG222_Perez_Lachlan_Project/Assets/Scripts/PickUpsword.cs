using UnityEngine;

public class PickUpsword : MonoBehaviour
{
    public GameObject SwordOnPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwordOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.SetActive(false);

                SwordOnPlayer.SetActive(true);
            }
        }
    }
}
