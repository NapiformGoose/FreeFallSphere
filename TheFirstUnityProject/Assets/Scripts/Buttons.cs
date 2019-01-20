using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    void OnMouseDown ()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
    void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
