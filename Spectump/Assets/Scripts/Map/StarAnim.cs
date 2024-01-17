using System.Collections;
using UnityEngine;

public class StarAnim : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float elapsedTime = 0f;
    private bool isFadingOut = true;


    public float fadeDurationMin = 1f;
    public float fateDurationMax = 5;
    private float fadeDuration;

    void Start()
    {
        fadeDuration = Random.Range(fateDurationMax, fadeDurationMin);
        spriteRenderer = GetComponent<SpriteRenderer>();

        float rot = Random.Range(0, 360);
        transform.Rotate(0, 0, rot);
    }

    void Update()
    {
        Opacity();
    }

    void Opacity()
    {
        elapsedTime += Time.deltaTime;
        float lerpFactor = Mathf.Clamp01(elapsedTime / fadeDuration);
        float opacity = isFadingOut ? Mathf.Lerp(1f, 0f, lerpFactor) : Mathf.Lerp(0f, 1f, lerpFactor);

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, opacity);

        if (elapsedTime >= fadeDuration)
        {
            elapsedTime = 0f;
            isFadingOut = !isFadingOut;
        }
    }
}
