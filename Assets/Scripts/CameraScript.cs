using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {   
        transform.position = player.transform.position + offset;
    }
}
