using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIDocument uiDoc;
    [SerializeField] ScriptableObjectsLevelInformation levelInfo;
    private VisualElement rootEL;
    private VisualElement buttonMenuEL;
    private List<Button> buttonMEL;
    private VisualElement buttonExitEL;
    private List<Button> buttonEEL;
    private VisualElement objectiveEL;
    private List<Label> objectiveLabelEL;

    private int badSubsTarget;
    private int goodSubsTarget;


    private void OnEnable() {
        rootEL = uiDoc.rootVisualElement;
        
        buttonMenuEL = rootEL.Q(className: "menus-list");
        buttonMEL = buttonMenuEL.Query<Button>().ToList();
        
        buttonExitEL = rootEL.Q(className: "exit-check");
        buttonEEL = buttonExitEL.Query<Button>().ToList();
        
        objectiveEL = rootEL.Q(className: "objective-panel-count");
        objectiveLabelEL = objectiveEL.Query<Label>().ToList();

        buttonMEL[0].clickable.clicked += (ExitButtonHandler);
        buttonMEL[1].clickable.clicked += (SettingsButtonHandler);
        buttonMEL[2].clickable.clicked += (PauseButtonHandler);
        buttonEEL[0].clickable.clicked += (ExitButtonHandlerYes);
        buttonEEL[1].clickable.clicked += (ExitButtonHandlerNo);

        badSubsTarget = levelInfo.LevelObjectives[0].badSubstanceMax;
        goodSubsTarget = levelInfo.LevelObjectives[0].goodSubstancePassGrade;
    }

    private void Update(){
        objectiveLabelEL[0].text = string.Format("{0}", goodSubsTarget);
        objectiveLabelEL[1].text = string.Format("{0}", badSubsTarget);
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

    public void OnBadEnter()
    {
        badSubsTarget -= 1;
        if (badSubsTarget <= 0){
            badSubsTarget = 0;
        }
    }
    public void OnGoodEnter()
    {
        goodSubsTarget -= 1;
        if (goodSubsTarget <= 0){
            goodSubsTarget = 0;
        }
    }
}
