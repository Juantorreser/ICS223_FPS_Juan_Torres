using UnityEngine;
using UnityEngine.UI;

public class OptionsPopup : BasePopup
{
    [SerializeField] private SettingsPopup settingsPopup;
    //public void Open()
    //{
    //    gameObject.SetActive(true);
    //}
    //public void Close()
    //{
    //    gameObject.SetActive(false);
    //}
    //public bool IsActive()
    //{
    //    return gameObject.activeSelf;
    //}
    public void OnSettingsButton()
    {
        settingsPopup.Open();
        Close();
    }
    public void OnExitGameButton()
    {
        Debug.Log("exit game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("return to game");
        Close();
    }
}
