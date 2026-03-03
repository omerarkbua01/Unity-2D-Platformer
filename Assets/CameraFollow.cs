using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0f,0f,-10f);


    void LateUpdate()
    {
        if(target ==null) return;
        transform.position=target.position + offset;
    }
}
