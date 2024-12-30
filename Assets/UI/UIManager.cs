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
    private bool isPaused;
    private bool isOnScreen;
    private int buttonIndex;


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
        GamePaused();
    }

    private void GamePaused(){
        if(isPaused){
            Time.timeScale = 0;
        }else if(!isPaused){
            Time.timeScale = 1f;
        }
    }

    private void ExitButtonHandler()
    {
        if(!isOnScreen)
        {
            buttonExitEL.AddToClassList("active");
            isOnScreen = true;
            isPaused = true;
            buttonIndex = 1;
        }else if (isOnScreen && buttonIndex == 1)
        {
            buttonExitEL.RemoveFromClassList("active");
            isOnScreen = false;
            isPaused = false;
        }
    }

    private void ExitButtonHandlerYes()
    {
        SceneManager.LoadScene(0);
        isPaused = false;
    }

    private void ExitButtonHandlerNo()
    {
        buttonExitEL.RemoveFromClassList("active");
        isOnScreen = true;
        isPaused = false;
    }

    private void SettingsButtonHandler()
    {
        if(!isOnScreen)
        {
            isOnScreen = true;
            isPaused = true;
            buttonIndex = 2;
        }else if (isOnScreen && buttonIndex == 2)
        {
            isOnScreen = false;
            isPaused = false;
        }
    }

    private void PauseButtonHandler()
    {
        if(!isOnScreen)
        {
            buttonMEL[2].AddToClassList("continue");
            isPaused = true;
            isOnScreen = true;
            buttonIndex = 3;
        }
        else if (isOnScreen && buttonIndex == 3)
        {
            buttonMEL[2].RemoveFromClassList("continue");
            isPaused = false;
            isOnScreen = false;
        }
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
