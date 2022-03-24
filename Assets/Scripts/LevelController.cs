using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelController : MonoBehaviour
{
    public GameObject stageHolder;
    public GameObject stageButton;
    public GameObject upperPanel;
    Rect panelD;
    Rect buttonD;
    public Vector2 buttonSpacing;
    int buttonCount;
    int stageCount=20;
    int currentButton;

    void Start()
    {
        panelD = stageHolder.GetComponent<RectTransform>().rect;
        buttonD = stageButton.GetComponent<RectTransform>().rect;
        int inRow = Mathf.FloorToInt(panelD.height / buttonD.height);
        int inCol = Mathf.FloorToInt(panelD.width / buttonD.width);
        buttonCount = inRow * inCol;
        int pageCount = Mathf.CeilToInt((float)stageCount / buttonCount);
        PanelPlacer(pageCount);
    }

    void PanelPlacer(int pageCount)
    {
        GameObject panelClown = Instantiate(stageHolder) as GameObject;
    
        for(int i = 1; i <= pageCount; i++)
        {
            GameObject panel= Instantiate(panelClown) as GameObject;
            panel.transform.SetParent(upperPanel.transform, false);
            panel.transform.SetParent(stageHolder.transform);
            panel.name = "Page " + i;
            panel.GetComponent<RectTransform>().localPosition = new Vector2(panelD.width * (i - 1), 0);
            SetUpGrid(panel);
            int numoButtons = i == pageCount ? stageCount - currentButton : buttonCount;
            ButtonPlacer(numoButtons, panel);
        }
        Destroy(panelClown);
    }

    void ButtonPlacer(int numoButtons, GameObject panel)
    {
        for (int i = 1; i <= numoButtons; i++)
        {
            currentButton++;
            GameObject button = Instantiate(stageButton) as GameObject;
            button.transform.SetParent(upperPanel.transform, false);
            button.transform.SetParent(panel.transform);
            button.name = "Level " + i;
            button.GetComponent<LevelHolder>().level = i;
            button.GetComponentInChildren<TextMeshProUGUI>().SetText("Level " + currentButton);
            button.GetComponent<Button>().onClick.AddListener(delegate () { LevelSelect(button.GetComponent<LevelHolder>().level); });
        }
    }

    void SetUpGrid(GameObject panel)
    {
        GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(buttonD.width, buttonD.height);
        grid.childAlignment = TextAnchor.MiddleCenter;
        grid.spacing = buttonSpacing;
    }

    public void LevelSelect (int i)
    {
        LevelHolder.Level = i;
        SceneManager.LoadScene("SampleScene");
    }




}
