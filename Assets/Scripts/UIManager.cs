using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public RectTransform mainMenu, levelsMenu, guideMenu, settingMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void LevelsButton()
    {
        mainMenu.DOAnchorPos(new Vector2(800, 0), 0.7f);
        levelsMenu.DOAnchorPos(new Vector2(0, 0), 0.7f);
    }

    public void CloseLevelsButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.7f);
        levelsMenu.DOAnchorPos(new Vector2(-800, 0), 0.7f);
    }

    public void GuideButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 1422), 0.7f);
        guideMenu.DOAnchorPos(new Vector2(0, 0), 0.7f);
    }

    public void CloseGuideButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.7f);
        guideMenu.DOAnchorPos(new Vector2(0, -1422), 0.7f);
    }

    public void SettingButton()
    {
        mainMenu.DOAnchorPos(new Vector2(-800, 0), 0.7f);
        settingMenu.DOAnchorPos(new Vector2(0, 0), 0.7f);
    }

    public void CloseSettingButton()
    {
        mainMenu.DOAnchorPos(new Vector2(0, 0), 0.7f);
        settingMenu.DOAnchorPos(new Vector2(800, 0), 0.7f);
    }
}
