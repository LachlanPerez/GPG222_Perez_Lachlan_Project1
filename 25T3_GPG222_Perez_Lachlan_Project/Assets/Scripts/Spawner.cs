using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public GameObject spawnItem;
    [SerializeField] public float frequency;
    [SerializeField] public float initialSpeed;
    public float lastSpawnedTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > lastSpawnedTime + frequency)
        {
            Spawn();
            lastSpawnedTime = Time.time;
        }
    }

    public void Spawn()
    {
        GameObject newSpawnedObject = Instantiate(spawnItem, transform.position, Quaternion.identity);   
        newSpawnedObject.GetComponent<Rigidbody>().linearVelocity = transform.forward * initialSpeed;
        newSpawnedObject.transform.parent = transform;
    }
}
