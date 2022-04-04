using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offSetPosition;
    public Vector3 offSetRotation;
    public float speed = 1;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject player;
    private Vector3 cameraPosition;

    private void Awake()
    {
        if (mainCamera == null) mainCamera = this.gameObject;
    }

    private void Set()
    {
        cameraPosition = player.transform.position + offSetPosition;
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraPosition, Time.deltaTime * speed);
        Vector3 pos = new Vector3(Mathf.Clamp(mainCamera.transform.position.x, -Player.Instance.limit.x + 40, Player.Instance.limit.x - 40),
            cameraPosition.y, Mathf.Clamp(mainCamera.transform.position.z, -Player.Instance.limit.y - 20, Player.Instance.limit.y - 80));
        mainCamera.transform.position = pos;
        //transform.position = cameraPosition;
    }

    private void Update()
    {
        Set();
    }
}
