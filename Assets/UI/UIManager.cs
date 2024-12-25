using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIDocument uiDoc;
    private VisualElement rootEL;
    private VisualElement buttonMenuEL;
    private List<Button> buttonMEL;
    private VisualElement buttonExitEL;
    private List<Button> buttonEEL;

    private void OnEnable() {
        rootEL = uiDoc.rootVisualElement;
        buttonMenuEL = rootEL.Q(className: "menus-list");
        buttonMEL = buttonMenuEL.Query<Button>().ToList();
        buttonExitEL = rootEL.Q(className: "exit-check");
        buttonEEL = buttonExitEL.Query<Button>().ToList();
    }
    private void Start() {
        buttonMEL[0].clickable.clicked += (ExitButtonHandler);
        buttonMEL[1].clickable.clicked += (SettingsButtonHandler);
        buttonMEL[2].clickable.clicked += (PauseButtonHandler);
        buttonEEL[0].clickable.clicked += (ExitButtonHandlerYes);
        buttonEEL[1].clickable.clicked += (ExitButtonHandlerNo);
    }

    private void ExitButtonHandler()
    {
        buttonExitEL.AddToClassList("active");
        Time.timeScale = 0;
    }

    private void ExitButtonHandlerYes()
    {
        SceneManager.LoadScene(0);
    }

    private void ExitButtonHandlerNo()
    {
        buttonExitEL.RemoveFromClassList("active");
        Time.timeScale = 1f;
    }

    private void SettingsButtonHandler()
    {
        Debug.Log("Settings");
    }

    private void PauseButtonHandler()
    {
        Debug.Log("Exit");
    }

}
