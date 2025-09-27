using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
   [SerializeField] Camera cam;

    // void Start()
    // {
    //     cam = Camera.main;
    // }

    void LateUpdate()
    {
        if (cam == null) return;
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
