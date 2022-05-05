using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SpawnTimer : MonoBehaviour
{
    private float time;
    private Text timerDisplay;

    // Start is called before the first frame update
    void Start()
    {
        time = -1f;
        timerDisplay = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, ((float)Screen.height) / Screen.width * 400, 0);
        if(time > 0f)
        {
            time -= Time.deltaTime;
            if(time < 0f)
            {
                time = 0f;
            }
            timerDisplay.text = "" + Mathf.Floor(time * 100) / 100f;
        }
        else if(time < 0f)
        {
            ResetTimer();
        }
    }

    public void ResetTimer()
    {
        time = Data.spawnTime;
    }
}
