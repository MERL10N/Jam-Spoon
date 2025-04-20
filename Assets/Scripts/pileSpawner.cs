using System.Xml.Linq;
using UnityEngine;

public class pileSpawner : MonoBehaviour
{
    public GameObject instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        instance = Instantiate(instance, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);

        if (instance.tag == "soda")
        {
            instance.transform.localScale = new Vector3(0.224f, 0.224f, 1);
        }
        else
        {
            instance.transform.localScale = new Vector3(0.112f, 0.112f, 1);
        }
        
        instance.SetActive(true);
    }
}
