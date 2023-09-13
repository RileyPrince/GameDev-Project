using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAimer : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
    }
}
