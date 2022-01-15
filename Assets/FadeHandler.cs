using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeHandler : MonoBehaviour
{
    SpriteRenderer sr;

    float remainingLifetime;
    float maxLifetime;
    float factor = 1f;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        remainingLifetime -= Time.deltaTime;
        if (remainingLifetime < maxLifetime/4f)
        {
            factor -= Time.deltaTime;
            sr.color = new Color(1, 1, 1, factor);
            if (factor <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetLifetime(float lifetime)
    {
        remainingLifetime = lifetime;
        maxLifetime = lifetime;
    }
}
