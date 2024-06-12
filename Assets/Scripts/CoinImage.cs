using TMPro;
using UnityEngine;
   
public class ScoreCoinPositioner : MonoBehaviour
{
    public RectTransform coinRectTransform;
    public TextMeshProUGUI scoreText;
    public float padding = 35f;

    void Update()
    {
        // Calculate the position of the coin image
        float xOffset = scoreText.preferredWidth + padding;
        coinRectTransform.anchoredPosition = new Vector2(xOffset, 0f);
    }
}