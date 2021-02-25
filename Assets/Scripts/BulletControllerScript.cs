using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerScript : MonoBehaviour
{
    public GameObject blood;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameObject clone = Instantiate(blood, other.transform.position, Quaternion.identity).gameObject;
            Destroy(clone, 0.5f);
            other.GetComponent<EnemyControllerScript>().hp -= 1;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
