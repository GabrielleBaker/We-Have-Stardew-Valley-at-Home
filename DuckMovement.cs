using UnityEngine;
using System.Collections;

public class DuckMovement : MonoBehaviour
{
    public GameObject Duck1;
    public GameObject Duck2;
    public float speed = 2f; // Speed of the duck
    private float startX = -24f; // Starting X position
    private float endX = -33f; // Ending X position
    private bool movingRightDuck1 = false; // Direction of movement for Duck1
    private bool movingRightDuck2 = false; // Direction of movement for Duck2

    void Start()
    {
        // Start the coroutine for duck movement
        StartCoroutine(DuckMoveCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        MoveDuck(Duck1, ref movingRightDuck1);
    }

    // Method to move a duck
    void MoveDuck(GameObject duck, ref bool movingRight)
    {
        // Move the duck
        if (movingRight)
        {
            duck.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            duck.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        // Check if the duck needs to flip direction
        if (duck.transform.position.x <= endX && !movingRight)
        {
            Flip(duck);
            movingRight = true;
        }
        else if (duck.transform.position.x >= startX && movingRight)
        {
            Flip(duck);
            movingRight = false;
        }
    }

    // Method to flip the duck
    void Flip(GameObject duck)
    {
        Vector3 localScale = duck.transform.localScale;
        localScale.x *= -1; // Flip the X axis
        duck.transform.localScale = localScale;
    }

    // Coroutine for duck movement
    IEnumerator DuckMoveCoroutine()
    {
        while (true)
        {
            // Pause for 3 seconds before flipping
            yield return new WaitForSeconds(3f);
            Flip(Duck2);

            // Pause for 5 seconds before starting to move
            yield return new WaitForSeconds(5f);

            // Move Duck2
            while ((movingRightDuck2 && Duck2.transform.position.x < startX) || (!movingRightDuck2 && Duck2.transform.position.x > endX))
            {
                MoveDuck(Duck2, ref movingRightDuck2);
                yield return null; // Wait for the next frame
            }

            // Ensure Duck2 flips again after reaching the end points
            Flip(Duck2);
        }
    }
}
