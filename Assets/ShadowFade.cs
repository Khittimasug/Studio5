using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowFade : MonoBehaviour
{
    [SerializeField] GameObject shadow;
    [SerializeField] float timeCd;
    private void Update()
    {
        timeCd += Time.deltaTime;

        if (timeCd > 0.01)
        {
            Instantiate(shadow,gameObject.transform.position,gameObject.transform.rotation,gameObject.transform.parent);
            timeCd = 0;
        }
    }
}
