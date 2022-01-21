using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public int combo;
    int swipe;
    bool checkSwipe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        int tap = collision.GetComponent<ObjectScript>().inputNeeded;

        if (collision.tag == "TapObject")
        {
            Debug.Log("TEST");
            for (int i = 0; i < Input.touchCount; i++)
            {
                Debug.Log("MASUK FOR, JUMLAH TAP : " + tap);
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    if (Input.GetTouch(i).tapCount == tap)
                    {
                        combo += 1;

                        if(combo >= 5)
                        {
                            score += collision.GetComponent<ObjectScript>().objectPoin * (int)1.2f;
                        }
                        else
                        {
                            score += collision.GetComponent<ObjectScript>().objectPoin;
                        }

                        Destroy(collision.gameObject);
                    }
                    else
                    {
                        combo = 0;
                    }
                }
            }
        }
        else if(collision.tag == "SwipeObject")
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Moved)
                {
                    Debug.Log("MOVED");
                    checkSwipe = true;
                }

                if (Input.GetTouch(i).phase == TouchPhase.Ended && checkSwipe)
                {
                    Debug.Log("END");
                    swipe++;
                }

                if (swipe == tap)
                {
                    combo += 1;
                    Debug.Log("MASUK SWIPE SCORE");

                    if (combo >= 5)
                    {
                        score += collision.GetComponent<ObjectScript>().objectPoin * (int)1.2f;
                    }
                    else
                    {
                        score += collision.GetComponent<ObjectScript>().objectPoin;
                    }
                    
                    swipe = 0;
                    Destroy(collision.gameObject);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Destroy(collision.gameObject);
    }
}
