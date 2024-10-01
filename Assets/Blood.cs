using UnityEngine;

public class Blood : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Destroy", 0.5f);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
