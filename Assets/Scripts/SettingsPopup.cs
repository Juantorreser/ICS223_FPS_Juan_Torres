using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingsPopup : BasePopup
{

    [SerializeField] private TextMeshProUGUI difficultyLabel;
    [SerializeField] private Slider slider;
    [SerializeField] private OptionsPopup optionsPopup;

    override public void Open()
    {
        Debug.Log(">>> SettingsPopup.Open() triggered");
        base.Open();
        slider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(slider.value);
    }


    //public void Close()
    //{
    //    gameObject.SetActive(false);
    //}
    //public bool IsActive()
    //{
    //    return gameObject.activeSelf;
    //}

    public void onOKButton()
    {

        PlayerPrefs.SetInt("difficulty", (int)slider.value);
        Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)slider.value);
        optionsPopup.Open();
        Close();
    }

    public void onCancelButton()
    {
        optionsPopup.Open();
        Close();
    }

    public void UpdateDifficulty(float difficulty)
    {
        difficultyLabel.text = "Difficulty: " +((int)difficulty).ToString();
    }
    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }
}
