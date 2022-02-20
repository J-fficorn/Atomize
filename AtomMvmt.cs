using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomMvmt : MonoBehaviour {

    private int dir;
    public float speed = 3f, orbitSpeed = 15f;
    private static float elevation = 1.5f;
    public float x_m = -5f, x_M = 5f, y_m = -7f, y_M = 7f;
    private Manager mng;
    private Controls crl;
    private bool moving;
    // Start is called before the first frame update
    void Start() {
        mng = FindObjectOfType<Manager>();
        crl = FindObjectOfType<Controls>();
        moving = true;
        if (transform.position.x == 0) { //n/s
            if (transform.position.y > 0) { //n
                dir = 0;
            } else { //s
                dir = 2;
            }
        } else {
            if (transform.position.x > 0) { //e
                dir = 1;
            } else { //w
                dir = 3;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (oob(transform.position.x, transform.position.y)) {
            mng.EndGame();
            Destroy(this.gameObject);
        }
        if (Physics.OverlapSphere(new Vector2(0, 0), elevation).Length > 2) elevation += 1;
        switch (dir) {
            case 0: {
                if (crl.up && moving) {
                    moving = false;
                    transform.position = new Vector2(0, elevation);
                    Invoke("Score", 0f);
                } else if (moving) {
                    transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
                }
                break;
            }
            case 1: {
                if (crl.right && moving) {
                    moving = false;
                    transform.position = new Vector2(elevation, 0);
                    Invoke("Score", 0f);
                } else if (moving) {
                    transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
                }
                break;
            }
            case 2: {
                if (crl.down && moving) {
                    moving = false;
                    transform.position = new Vector2(0, -elevation);
                    Invoke("Score", 0f);
                } else if (moving) {
                    transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
                }
                break;
            }
            case 3: {
                if (crl.left && moving) {
                    moving = false;
                    transform.position = new Vector2(-elevation, 0);
                    Invoke("Score", 0f);
                } else if (moving) {
                    transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
                }
                break;
            }
        }
        if (!moving) transform.RotateAround(new Vector2(0, 0), Vector3.back, orbitSpeed * Time.deltaTime);
    }

    bool oob(float x, float y) {
        return !(x > x_m && x < x_M && y > y_m && y < y_M); //t if out, f if in
    }

    void Score() {
        mng.score++;
    }
}
