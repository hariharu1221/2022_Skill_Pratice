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

    private List<Renderer> ObstacleRenderer;
    private List<Renderer> AfterRenderer;

    private void Awake()
    {
        ObstacleRenderer = new List<Renderer>();
        AfterRenderer = new List<Renderer>();
    }

    private void LateUpdate()
    {

    }

    private void Set()
    {
        cameraPosition = player.transform.position + offSetPosition;
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, cameraPosition, Time.deltaTime * speed);
        //transform.position = cameraPosition;

        Quaternion SetRotation = Quaternion.Euler(offSetRotation) * player.transform.rotation;
        mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, SetRotation, Time.deltaTime * speed * 10);
       // transform.rotation = SetRotation;
    }

    private void Update()
    {
        Set();

        Vector3 pos = player.transform.position - new Vector3(0, -0.5f, 0);
        float Distance = Vector3.Distance(transform.position, pos);
        Vector3 Direction = (pos - transform.position);
        List<RaycastHit> hits = Physics.RaycastAll(transform.position, Direction, Distance, LayerMask.GetMask("Block")).ToList();

        Debug.DrawRay(transform.position, Direction, Color.green);

        if (hits.Count != 0) //Block이라는 Layer를 가진 오브젝트에 부딫혔는가?
        {
            List<Renderer> list = new List<Renderer>();
            foreach (RaycastHit hit in hits)
            {
                list.Add(hit.transform.GetComponentInChildren<Renderer>());
            }

            ObstacleRenderer = list;

            if (ObstacleRenderer != AfterRenderer)
            {
                RevertRenderer();
            }

            foreach (Renderer renderer in ObstacleRenderer) //Metrial의 Aplha를 바꾼다.
            {
                Material mat = renderer.material;
                RenderingUtils.SetRenderingMode(RenderingMode.Fade, mat);
                RenderingUtils.SetAlpha(0.3f, mat);
            }

            AfterRenderer = ObstacleRenderer;
        }
        else
        {
            RevertRenderer();
        }
    }

    private void RevertRenderer()
    {
        foreach (Renderer renderer in AfterRenderer) //Metrial의 Aplha를 바꾼다.
        {
            Material mat = renderer.material;
            RenderingUtils.SetRenderingMode(RenderingMode.Opaque, mat);
            RenderingUtils.SetAlpha(1f, mat);
        }
        AfterRenderer.Clear();
    }
}
