using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        string tag = other.gameObject.tag;
        Debug.Log(tag);
        if (!other.gameObject.CompareTag("Untagged")) {
            GameManager.instance.AddPoints(getPointsByTag(tag));
        }
    }

    private int getPointsByTag(string tag) { 
        switch (tag) {
            case "Stick1":
                return 100;
            case "Stick2":
                return 150;
            case "Stick3":
                return 300;
            case "Stick4":
                return 50;
            default:
                return 0;
        }
    }
}
