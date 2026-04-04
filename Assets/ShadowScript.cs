using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    public Transform player;       // ตัวผู้เล่น
    public float shadowHeight = 0f; // ระดับความสูงของเงา (แกน Y)

    void Update()
    {
        if (player == null) return;

        // ดึงตำแหน่งผู้เล่น
        Vector3 pos = player.position;

        // ให้เงาตามแค่ X, Z และตรึง Y ไว้
        transform.position = new Vector3(pos.x, shadowHeight, pos.z);
    }
}
