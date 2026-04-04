using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countDown : MonoBehaviour
{
    public TextMeshProUGUI sec;
    public TextMeshProUGUI min;
    public TextMeshProUGUI hour;

    public TextMeshProUGUI shadowsec;
    public TextMeshProUGUI shadowmin;
    public TextMeshProUGUI shadowhour;
    // Start is called before the first frame update
    private float time;
    void Start()
    {
        time = int.Parse(sec.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 10)
        {
            sec.text = "0" + Mathf.Round(time).ToString();
        }
        else
        {
            sec.text = Mathf.Round(time).ToString();
        }
        time -= Time.deltaTime;

        
        if (time <= 0)
        {
            if ((int.Parse(min.text) - 1) < 10)
            {
                min.text = "0" + (int.Parse(min.text) - 1).ToString();
            }
            else
            {
                min.text = (int.Parse(min.text) - 1).ToString();
            }
            time = 59;
        }

        if (time >= 60)
        {
            if ((int.Parse(min.text) - 1) < 10)
            {
                min.text = "0" + (int.Parse(min.text) - 1).ToString();
            }
            else
            {
                min.text = (int.Parse(min.text) - 1).ToString();
            }
        }
        shadowhour.text = hour.text;
        shadowmin.text = min.text;
        shadowsec.text = sec.text;
    }
}
