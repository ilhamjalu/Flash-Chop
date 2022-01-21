using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText;
    public GameObject[] objectSpawn;
    public Transform spawnPos;

    public float timer;
    bool startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = true;
        InvokeRepeating("SpawnObject", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime)
        {
            timer -= Time.deltaTime;
            int timerConv = (int)timer;

            if (timerConv <= 0)
            {
                CancelInvoke("SpawnObject");
                startTime = false;
                timerConv = 0;
            }

            timerText.text = timerConv.ToString();
        }
    }

    void SpawnObject()
    {
        int r = Random.Range(0, objectSpawn.Length);

        GameObject spawnObj = Instantiate(objectSpawn[r], spawnPos.position, Quaternion.identity);
        spawnObj.transform.SetParent(GameObject.Find("Canvas").transform);
        spawnObj.transform.localScale = new Vector3(1, 1, 1);
    }
}
