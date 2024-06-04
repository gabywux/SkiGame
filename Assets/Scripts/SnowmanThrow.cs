using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanThrow : MonoBehaviour
{
    public float throwDistance;
    public int throwSpeed;
    public float throwDelay = 0f;
    public float throwInterval =1f;

    public GameObject player;
    public bool canThrow = true;

    private void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("ThrowSnowball", throwDelay, throwInterval);
    }

    private void ThrowSnowball()
    {
        if (player != null && canThrow)
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            if (distanceToPlayer < throwDistance)
            {
                GameObject snowball = SnowballPool.Instance.GetSnowballFromPool();
                if (snowball != null)
                {
                    snowball.transform.position = transform.position;
                    snowball.SetActive(true);

                    Vector3 direction = (player.transform.position - transform.position).normalized;
                    snowball.GetComponent<Rigidbody>().velocity = direction * throwSpeed;
                }
            }
        }
    }
}
