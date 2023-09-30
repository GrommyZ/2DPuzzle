using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerText_Restart : MonoBehaviour
{
    public float fadeTime = 0.5f;

    private TextMeshProUGUI text;
    private bool fadingIn = false;
    private bool fadingOut = false;
    private float timer = 0f;

    private void Start()
    {
        text = GameObject.Find("text_restart").GetComponent<TextMeshProUGUI>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            fadingIn = true;
            fadingOut = false;
            timer = 0f;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (fadingIn)
            {
                timer += Time.deltaTime;
                float alpha = Mathf.Lerp(0f, 1f, timer / fadeTime);
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

                if (timer >= fadeTime)
                {
                    fadingIn = false;
                    timer = 0f;
                }
            }
            else if (!fadingOut)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, 1f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            fadingOut = true;
            fadingIn = false;
            timer = 0f;
        }
    }

    private void Update()
    {
        if (fadingOut)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeTime);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

            if (timer >= fadeTime)
            {
                fadingOut = false;
            }
        }
    }
}
