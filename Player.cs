using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private bool movingRight = false;
    public GameObject player;
    // Movement with joystick
    public FixedJoystick joystick;
    public float movementSpeed;
    float horizontalInput, verticalInput;

    // Collections
    public TextMeshProUGUI carrotCountText;
    int carrotCount = 0;

    public TextMeshProUGUI eggCountText;
    int eggCount = 0;

    public TextMeshProUGUI grass1CountText;
    int grass1Count = 0;

    public TextMeshProUGUI grass2CountText;
    int grass2Count = 0;

    //public GameObject winText;
    public GameObject egg;

    // Start is called before the first frame update
    void Start()
    {
        UpdateItemCountText(carrotCountText, carrotCount);
        UpdateItemCountText(eggCountText, eggCount);
        UpdateItemCountText(grass1CountText, grass1Count);
        UpdateItemCountText(grass2CountText, grass2Count);
    }

    // Update is called once per frame
    void Update()
    {
        // Check the horizontal input to determine direction and flip sprite if necessary
        if (horizontalInput > 0 && !movingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && movingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        horizontalInput = joystick.Horizontal * movementSpeed;
        verticalInput = joystick.Vertical * movementSpeed;

        // Move player along x and y axis, no z due to 2D
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Carrot")
        {
            carrotCount++;
            Destroy(collision.gameObject);
            Debug.Log(carrotCount);
            UpdateItemCountText(carrotCountText, carrotCount);
        }

        if (collision.gameObject.tag == "Grass1")
        {
            grass1Count++;
            Destroy(collision.gameObject);
            egg.SetActive(true);
            Debug.Log(grass1Count);
            UpdateItemCountText(grass1CountText, grass1Count);
        }

        if (collision.gameObject.tag == "Egg")
        {
            eggCount++;
            Destroy(collision.gameObject);
            Debug.Log(eggCount);
            UpdateItemCountText(eggCountText, eggCount);
        }

        if (collision.gameObject.tag == "Grass2")
        {
            grass2Count++;
            Destroy(collision.gameObject);
            egg.SetActive(true);
            Debug.Log(grass2Count);
            UpdateItemCountText(grass2CountText, grass2Count);
        }
    }

    void UpdateItemCountText(TextMeshProUGUI itemText, int count)
    {
        // Update the text element to show the current item count
        itemText.text = count.ToString();
    }

    // Method to flip the player sprite
    private void Flip()
    {
        movingRight = !movingRight;
        Vector3 localScale = player.transform.localScale;
        localScale.x *= -1;
        player.transform.localScale = localScale;
    }
}
