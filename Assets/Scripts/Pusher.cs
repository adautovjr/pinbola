using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pusher : MonoBehaviour {
    bool ballInPlace = false;
    Rigidbody rb = null;
    float power = 0f;
    float minPower = 0f;
    public float maxPower = 100f;
    public int force = 50;
    public Slider powerSlider;

    // Start is called before the first frame update
    void Start() {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
    }

    // Update is called once per frame
    void Update() {
        powerSlider.value = power;
        float pusherInput = Input.GetAxis("Pusher");
        
        powerSlider.gameObject.SetActive(ballInPlace);
        if (ballInPlace) {
            if (pusherInput > 0) {
                if (power <= maxPower) {
                    power += 50 * pusherInput * Time.deltaTime;
                }
            } else {
                if (rb != null) {
                    rb.AddForce((power * 0.20f) * Vector3.left);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            rb = other.gameObject.GetComponent<Rigidbody>();
            ballInPlace = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            rb = null;
            power = 0f;
            ballInPlace = false;
        }
    }
}
