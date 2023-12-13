
using UnityEngine;
using UnityEngine.UI;

public class BackgroundLoop : MonoBehaviour
{

    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;

    // Start is called before the first frame update
    void Start()
    {
        _img = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }
}
