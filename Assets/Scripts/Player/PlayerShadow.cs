using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    private float fy;

    private void Start()
    {
        fy = transform.position.y;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, fy, transform.position.z);
    }
}
