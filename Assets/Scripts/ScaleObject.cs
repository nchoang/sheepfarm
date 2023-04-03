using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    Vector3 originalScale;

    [SerializeField]
    private float toScale;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
        transform.localScale = new Vector3(originalScale.x * width * toScale, originalScale.y * width * toScale, originalScale.z);
    }
}
