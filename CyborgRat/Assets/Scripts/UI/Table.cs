using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Table : MonoBehaviour
{
    private string[] _data = { };
    public string[] data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value;
            DrawLayout();
        }
    }

    CanvasGroup canvas;
    List<GameObject> tableRows = new List<GameObject>();

    private float distanceBetweenRows = 50.0f;
    private float distanceBetweenColumns = 130.0f;
    private float startingYPosition = -20.0f;

    private void Start()
    {
        canvas = gameObject.GetComponent<CanvasGroup>();

        DrawLayout();
    }

    void DrawLayout() {
        float yPosition = startingYPosition;
        foreach (string rowData in data)
        {
            GameObject row = CreateRow(rowData);
            tableRows.Add(row);
            row.transform.position = moveYPosition(canvas.transform.position, yPosition);
            row.transform.SetParent(canvas.transform);
            yPosition -= distanceBetweenRows; 
        }
    }

    Vector3 moveYPosition(Vector3 canvasPosition, float y)
    {
        canvasPosition.y += y;
        return canvasPosition;
    }

    GameObject CreateRow(string rowData)
    {
        GameObject playerName = CreateLabel(rowData, false);
        playerName.transform.position = new Vector3(-distanceBetweenColumns, 0, 0);
        GameObject row = new GameObject();
        playerName.transform.SetParent(row.transform);

        return row;
    }

    GameObject CreateLabel(string text, bool leftAligment)
    {
        GameObject label = new GameObject();
        TextMeshProUGUI textLabel = label.AddComponent<TextMeshProUGUI>();
        textLabel.alignment = leftAligment ? TextAlignmentOptions.Left : TextAlignmentOptions.Right;
        textLabel.text = text;
        textLabel.faceColor = Color.white;
        return label;
    }

    void ChangeRowColor(GameObject row, Color color)
    {
        for (int j = 0; j < row.transform.childCount; ++j)
        {
            TextMeshProUGUI label = row.transform.GetChild(j).GetComponent<TextMeshProUGUI>();
            if (label == null) continue;
            label.faceColor = color;
        }
    }

    public void HighlightRow(int index)
    {
        for (int i = 0; i < tableRows.Count; ++i)
        {
            GameObject row = tableRows[i];
            Color rowColor = (index == i) ? Color.red : Color.white;
            ChangeRowColor(row, rowColor);
        }
    }
}
