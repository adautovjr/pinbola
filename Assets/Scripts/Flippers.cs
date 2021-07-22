using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flippers : MonoBehaviour {
    public float restPos = 0f;
    public float pressedPos = 60f;
    public float hitStrenght = 10000f;
    public float flipperDamper = 150f;
    HingeJoint hinge;
    public string inputName;

    // Start is called before the first frame update
    void Start() {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
    }

    // Update is called once per frame
    void Update() {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrenght;
        spring.damper = flipperDamper;

        if (Input.GetAxis(inputName) == 1) {
            spring.targetPosition = pressedPos;
        } else {
            spring.targetPosition = restPos;
        }
        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
