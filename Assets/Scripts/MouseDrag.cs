using System;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePt = Input.mousePosition;
        mousePt.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePt);
    }

    // Update is called once per frame
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }
}
