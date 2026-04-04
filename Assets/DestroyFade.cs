using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFade : MonoBehaviour
{
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
