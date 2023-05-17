using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyBullet : MonoBehaviour
{
    [SerializeField] private LayerMask bulletMask;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }

}
