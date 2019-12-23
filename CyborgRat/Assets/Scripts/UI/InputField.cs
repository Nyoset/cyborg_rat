using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class InputField : MonoBehaviour, IPointerClickHandler
{
    public string labelText;
    public string placeholderText;

    TMP_InputField input;
    public TextMeshProUGUI label;
    public TextMeshProUGUI placeholderLabel;

    private void Awake()
    {
        input = gameObject.GetComponentInChildren<TMP_InputField>();

        label.text = labelText;
        placeholderLabel.text = placeholderText;
    }

    private void Start()
    {
        input.Select();
        input.ActivateInputField();
    }

    public void OnClickInputField()
    {
        input.Select();
    }

    public string GetInputText()
    {
        return input.text;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickInputField();
    }
}
