using UnityEngine;

public class HotDogLogic : MonoBehaviour
{
    public GameObject collidedObject;
    public GameObject hotdog;
    public new Collider2D collider2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hotdog = Instantiate(hotdog);
        collider2D = GetComponent<Collider2D>();
        hotdog.SetActive(false);
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
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((tag == "sausage" && collision.gameObject.tag == "bun") || (tag == "bun" && collision.gameObject.tag == "sausage"))
        {
            collidedObject = collision.gameObject;
        }
        
    }

    public void CombineElements(GameObject element1, GameObject element2)
    {
        hotdog = Instantiate(hotdog, new Vector3(transform.position.x, transform.position.y, -1.2f), transform.rotation);
        element1.SetActive(false);
        element2.SetActive(false);
        hotdog.SetActive(true);

    }
}
