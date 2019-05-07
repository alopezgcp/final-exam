using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 newpos = Input.mousePosition;
        newpos.z = transform.position.z;
        transform.position = newpos;
    }
}
