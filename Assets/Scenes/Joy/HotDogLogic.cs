using UnityEngine;

public class HotDogLogic : MonoBehaviour
{
    public GameObject collidedObject;
    public GameObject result;
    public new Collider2D collider2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseUp()
    {
        if (collider2D.IsTouching(collidedObject.GetComponent<Collider2D>()))
        {
            if ((tag == "sausage" && collidedObject.tag == "bun") || (tag == "bun" && collidedObject.tag == "sausage"))
            {
                CombineElements(gameObject, collidedObject);
            }

            else if ((tag == "popcorn" && collidedObject.tag == "fish") || (tag == "fish" && collidedObject.tag == "popcorn"))
            {
                result = GameObject.Find("fishpopcorn");
                result = Instantiate(result);
                CombineElements(gameObject, collidedObject);
            }

            else if ((tag == "fry" && collidedObject.tag == "ice cream") || (tag == "ice cream" && collidedObject.tag == "fry"))
            {
                result = GameObject.Find("ice cream fries");
                result = Instantiate(result);
                CombineElements(gameObject, collidedObject);
            }

            else if ((tag == "fry" && collidedObject.tag == "fish") || (tag == "fish" && collidedObject.tag == "fry"))
            {
                result = GameObject.Find("fish fries");
                result = Instantiate(result);
                CombineElements(gameObject, collidedObject);
            }

            else if ((tag == "fry" && collidedObject.tag == "nugget") || (tag == "nugget" && collidedObject.tag == "fry"))
            {
                result = GameObject.Find("nugget fries");
                result = Instantiate(result);
                CombineElements(gameObject, collidedObject);
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((tag == "sausage" && collision.gameObject.tag == "bun") || (tag == "bun" && collision.gameObject.tag == "sausage"))
        {
            collidedObject = collision.gameObject;
        }

        else if ((tag == "popcorn" && collision.gameObject.tag == "fish") || (tag == "fish" && collision.gameObject.tag == "popcorn"))
        {
            collidedObject = collision.gameObject;
        }

        else if ((tag == "fry" && collision.gameObject.tag == "ice cream") || (tag == "ice cream" && collision.gameObject.tag == "fry"))
        { 
            collidedObject = collision.gameObject;
        }

        else if ((tag == "fry" && collision.gameObject.tag == "fish") || (tag == "fish" && collision.gameObject.tag == "fry"))
        {
            collidedObject = collision.gameObject;
        }

        else if ((tag == "fry" && collision.gameObject.tag == "nugget") || (tag == "nugget" && collision.gameObject.tag == "fry"))
        {
            collidedObject = collision.gameObject;
        }

    }

    public void CombineElements(GameObject element1, GameObject element2)
    {
        result = Instantiate(result, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);
        element1.transform.position *= 100;
        element1.SetActive(false);
        element2.transform.position *= 100;
        element2.SetActive(false);
        result.SetActive(true);

    }
}
