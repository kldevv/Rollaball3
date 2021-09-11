using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject deadTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        speed = 15;
        count = 0;
        winTextObject.SetActive(false);
        deadTextObject.SetActive(false);
        SetCountText();
    }

    private void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate() {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
    
        if (transform.position.y < -5 && count < 13) {
            deadTextObject.SetActive(true);
        }

        rb.AddForce(movement * speed);
    }

    void SetCountText() {
        countText.text = "Points: " + count.ToString();
        if (count >= 13)
            winTextObject.SetActive(true);
                    // Set the text value of your 'winText'
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("PickUp2")) {
            other.gameObject.SetActive(false);
            count += 2;
            SetCountText();
        }
    }
}