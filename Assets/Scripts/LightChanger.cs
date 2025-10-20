using UnityEngine;

public class LightChanger : MonoBehaviour
{
    [SerializeField]
    private float cycleSpeed = 0.5f;

    private Light myLight;

    private float currentHue = 0f;

    void Awake()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        currentHue += cycleSpeed * Time.deltaTime;

        if (currentHue > 1f)
        {
            currentHue -= 1f;
        }

        myLight.color = Color.HSVToRGB(currentHue, 1f, 1f);
    }
}
