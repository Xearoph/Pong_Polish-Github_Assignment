using System;
using UnityEngine;

public class BackgroundEffects : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    public GameObject wallLeft;
    public GameObject wallRight;
    // Start is called before the first frame update
    void Start()
    {
        wallRight = GameObject.FindGameObjectWithTag("BoundRight");
        wallLeft = GameObject.FindGameObjectWithTag("BoundLeft");
        ball = GameObject.FindGameObjectWithTag("Player");
        
        if (ball.TryGetComponent<BackgroundEffects>(out _))
        {
            Debug.Log("After added.");
        }
        else
        {
            Debug.Log("Script added.");
            ball.AddComponent<BackgroundEffects>();
        }

      

      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        System.Random random = new System.Random();
        int[] colors = { 1, 2, 3, 4, 5 };
        int randomColor = random.Next(colors.Length);
        int value = colors[randomColor]; 

        if (collision.gameObject.tag == "BoundLeft" || collision.gameObject.tag == "BoundRight")
        {
            switch (value)
            {
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
