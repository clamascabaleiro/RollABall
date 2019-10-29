using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private Rigidbody player;
    private int count;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Enter");
    }
    
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }

        if (other.gameObject.CompareTag( "Enemigo"))
        {
            countText.text = "Oughh!!!!!";
            count = count - 3;
            // vuelve al centro del tablero
           player.transform.position = Vector3.one;
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 12)
        {
            winText.text = "You Win!";
            countText.text = "You Win!";
            Destroy(gameObject);
            
        }
        
    }
}
