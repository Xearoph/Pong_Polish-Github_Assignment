using System;
using UnityEngine;

public class BackgroundEffects : MonoBehaviour
{
    /// <summary>
    /// The first GameObject is that of the ball. I serialize this so that I can use it in the Unity Inspector, but it can't be used in other scripts.
    /// The other two GameObjects are for the walls on the side. 
    /// I assign these in the Inspector so I can use them in Unity.
    /// </summary>
    [SerializeField] private GameObject ball;
    public GameObject wallLeft;
    public GameObject wallRight;

    // Start is called before the first frame update
    void Start()
    {
        // Below, I link the GameObjects to the Unity object they have by looking at the tags.
        wallRight = GameObject.FindGameObjectWithTag("BoundRight");
        wallLeft = GameObject.FindGameObjectWithTag("BoundLeft");
        ball = GameObject.FindGameObjectWithTag("Player");
        
        // In this small If statement, I look if the script has been added to the correct Object by trying to get the component.
        if (ball.TryGetComponent<BackgroundEffects>(out _))
        {
            // Small log to see if it works or not.
            Debug.Log("After added.");
        }
        // If the above if statement is wrong, the below else runs.
        else
        {
            // Another log for checking.
            Debug.Log("Script added.");
            // Adds this script to the ball object in Unity.
            ball.AddComponent<BackgroundEffects>();
        }
    }

    // An OnTriggerEnter method basically just checks for a trigger.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // A Random lets you pick random values from, for example, an int array.
        System.Random random = new System.Random();
        // This int array is used for getting a random value for changing the background color.
        int[] colors = { 1, 2, 3, 4, 5 };
        // Takes a random number from how many values are in the colors array. F.E. if there are 7 values in  the array, the Random takes a number 1-7.
        int randomColor = random.Next(colors.Length);
        // Here, I assign value to one of the colors. The randomColor takes one of the values in the colors array.
        int value = colors[randomColor]; 

        // Checks if the collision is with the tag BoundLeft or BoundRight, aka the left and right walls.
        if (collision.gameObject.tag == "BoundLeft" || collision.gameObject.tag == "BoundRight")
        {
            // Switch statement for checking what number got assigned to value.
            switch (value)
            {
                // If the number would be 1, the background color of the scene would be changed to red.
                // If it was 2, it would be changed to yellow, and so on.
                case 1:
                    Camera.main.backgroundColor = Color.red;
                    break;
                case 2:
                    Camera.main.backgroundColor = Color.yellow;
                    break;
                case 3:
                    Camera.main.backgroundColor = Color.blue;
                    break;
                case 4:
                    Camera.main.backgroundColor = Color.green;
                    break;
                case 5: 
                    Camera.main.backgroundColor = Color.black;
                    break;
            }
        }
    }
}
