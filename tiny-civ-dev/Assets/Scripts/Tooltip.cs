using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text tooltipTitle;
    [SerializeField] TMP_Text tooltipText;

    public void Start()
    {
        panel.SetActive(false);
    }

    void Update()
    {
        // Show tooltip by mouse
        if (panel.activeSelf)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                panel.transform.parent as RectTransform,
                Input.mousePosition,
                null,
                out pos
            );
            panel.transform.localPosition = pos + new Vector2(10, -10); // small offset
        }
    }
    public void Show(string titleText, string text)
    {
        tooltipTitle.text = titleText;
        tooltipText.text = text;
        panel.SetActive(true);
    }
    public void Hide()
    {
        panel.SetActive(false);
    }
}