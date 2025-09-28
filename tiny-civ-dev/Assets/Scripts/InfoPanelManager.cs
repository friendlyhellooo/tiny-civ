using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoPanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text titleText;
    [SerializeField] TMP_Text infoText;
    [SerializeField] Image iconImage;

    void Start()
    {
        panel.SetActive(false);
    }

    public void OpenPanel(string title, string info, Sprite icon)
    {
        titleText.text = title;
        infoText.text = info;
        iconImage.sprite = icon;
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public bool PanelIsActive()
    {
        return panel.activeSelf;
    }
}
