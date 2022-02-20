using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public int Interval = 480;
    private int step = 0;
    public int size = 15, score = 0;
    public GameObject circ;
    private int[] directions;
    private bool ended = false;

    // Start is called before the first frame update
    void Start()
    {
        directions = new int[size];
        for (int i = 0; i < size; i++) {
            directions[i] = Random.Range(0, 4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % Interval == 0 && step < size) { 
            spawn(directions[step]);
            step++;
        }
    }

    void spawn(int dir) {
        switch (dir) {
            case 0: {
                GameObject newCircle = (GameObject) Instantiate (circ, new Vector2(0, 6), Quaternion.identity); break;
            }
            case 1: {
                GameObject newCircle = (GameObject) Instantiate (circ, new Vector2(4, 0), Quaternion.identity); break;
            }
            case 2: {
                GameObject newCircle = (GameObject) Instantiate (circ, new Vector2(0, -6), Quaternion.identity); break;
            }
            case 3: {
                GameObject newCircle = (GameObject) Instantiate (circ, new Vector2(-4, 0), Quaternion.identity); break;
            }
        }
    }

    public void EndGame() {
        if (!ended) {
            ended = true;
            Debug.Log("Game Over");
            Invoke("Restart", 5f);
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
