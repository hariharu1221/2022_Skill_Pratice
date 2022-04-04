using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    public List<GameObject> scrollObj = new List<GameObject>();
    public float speed = 50f;

    private Vector3 resetPos;

    private void Awake()
    {
        resetPos = scrollObj[scrollObj.Count - 1].transform.position;
    }

    private void Update()
    {
        for (int i = 0; i < scrollObj.Count; i++)
            scrollObj[i].transform.position += Vector3.back * speed * Time.deltaTime;

        if (scrollObj[0].transform.position.z < -1200)
        {
            GameObject n = scrollObj[0];
            n.transform.position = resetPos;
            scrollObj.RemoveAt(0);
            scrollObj.Add(n);
        }
    }
}
