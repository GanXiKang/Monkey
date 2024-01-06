using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorControl : MonoBehaviour
{
    public GameObject[] map = new GameObject[5];

    int colliderNum;

    void Start()
    {
        colliderNum = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            colliderNum++;
            if (colliderNum == 1)
            {
                int s = Random.Range(0, 5);
                Instantiate(map[s], transform.position + new Vector3(0, 0, -250), transform.rotation);
            }
            else
            {
                Destroy(gameObject, 2f);
            }
        }
    }
}
