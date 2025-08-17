using UnityEngine;

public class Filip_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(Vector2.down);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(Vector2.up);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(Vector2.right);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(Vector2.left);
        }
    }
}
