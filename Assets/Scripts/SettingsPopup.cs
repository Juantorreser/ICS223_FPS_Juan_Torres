using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingsPopup : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI difficultyLabel;
    [SerializeField] private Slider slider;
    [SerializeField] private OptionsPopup optionsPopup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }

    public void onOKButton()
    {
        Close();
        optionsPopup.Open();
        PlayerPrefs.SetInt("difficulty", (int)slider.value);
    }

    public void onCancelButton()
    {
        Close();
        optionsPopup.Open();
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
