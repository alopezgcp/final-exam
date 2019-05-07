using UnityEngine;

public class Minimap : MonoBehaviour
{
    void Update()
    {
        Vector3 newpos = Input.mousePosition;
        newpos.z = transform.position.z;
        transform.position = newpos;
    }
}
