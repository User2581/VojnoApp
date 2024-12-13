using System.IO;  // To handle file IO
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;

    // public GameObject activePlayerScreen;
    public GameObject ammo;
    public GameObject compass;
    public GameObject health;
    public GameObject countdown;


    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject pauseScreen;

    public GameObject winScreenBackround;
    public GameObject loseScreenBackround;
    public GameObject pauseScreenBackround;

    public GameObject settingsPanel;      // The settings panel
    public InputField positionXInput;     // Input Field for Position X
    public InputField positionYInput;     // Input Field for Position Y
    public InputField positionZInput;     // Input Field for Position Z
    public InputField rotationXInput;     // Input Field for Rotation X
    public InputField rotationYInput;     // Input Field for Rotation Y
    public InputField rotationZInput;     // Input Field for Rotation Z
    public InputField scaleXInput;        // Input Field for Scale X
    public InputField scaleYInput;        // Input Field for Scale Y
    public InputField scaleZInput;        // Input Field for Scale Z
    public Button applyButton;            // Apply button for settings
    public Button closeButton;            // Close button for settings
    public Button saveButton;             // Save button for CSV

    public Transform parentSkyMap;        // The ParentSkyMap object to modify


    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        positionXInput.text = parentSkyMap.position.x.ToString();
        positionYInput.text = parentSkyMap.position.y.ToString();
        positionZInput.text = parentSkyMap.position.z.ToString();

        rotationXInput.text = parentSkyMap.rotation.eulerAngles.x.ToString();
        rotationYInput.text = parentSkyMap.rotation.eulerAngles.y.ToString();
        rotationZInput.text = parentSkyMap.rotation.eulerAngles.z.ToString();

        scaleXInput.text = parentSkyMap.localScale.x.ToString();
        scaleYInput.text = parentSkyMap.localScale.y.ToString();
        scaleZInput.text = parentSkyMap.localScale.z.ToString();

        applyButton.onClick.AddListener(ApplySettings);
        closeButton.onClick.AddListener(CloseSettings);
    }

    public void TriggerWinScreen()
    {
        gameManager.ChangePauseGameState(true);
        // activePlayerScreen.SetActive(false);
        SetActivePlayerScreen(false);
        winScreenBackround.SetActive(true);
        winScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void TriggerLoseScreen()
    {
        gameManager.ChangePauseGameState(true);
        // activePlayerScreen.SetActive(false);
        SetActivePlayerScreen(false);
        loseScreenBackround.SetActive(true);
        loseScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PauseGame()
    {
        gameManager.ChangePauseGameState(true);
        // activePlayerScreen.SetActive(false);
        SetActivePlayerScreen(false);
        pauseScreenBackround.SetActive(true);
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseScreenBackround.SetActive(false);
        pauseScreen.SetActive(false);
        // activePlayerScreen.SetActive(true);
        SetActivePlayerScreen(true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameManager.ChangePauseGameState(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void SetActivePlayerScreen(bool isActive)
    {
        ammo.SetActive(isActive);
        compass.SetActive(isActive);
        health.SetActive(isActive);
        countdown.SetActive(isActive);
    }

    public void ToggleSettingsMenu()
    {
        if (pauseScreen.activeSelf)
        {
            pauseScreenBackround.SetActive(false);
            pauseScreen.SetActive(false);
        }

        settingsPanel.SetActive(!settingsPanel.activeSelf);
        Debug.Log("Settings panel is " + (settingsPanel.activeSelf ? "active" : "inactive"));
    }

    // Apply the settings (volume and fullscreen)
    public void ApplySettings()
    {
        //Debug.Log("Settings Applied!");

        //float posX = TryParseFloat(positionXInput.text, parentSkyMap.position.x);
        //float posY = TryParseFloat(positionYInput.text, parentSkyMap.position.y);
        //float posZ = TryParseFloat(positionZInput.text, parentSkyMap.position.z);
        //parentSkyMap.position = new Vector3(posX, posY, posZ);
        //Debug.Log($"New position: {parentSkyMap.position}");

        //float rotX = TryParseFloat(rotationXInput.text, parentSkyMap.rotation.eulerAngles.x);
        //float rotY = TryParseFloat(rotationYInput.text, parentSkyMap.rotation.eulerAngles.y);
        //float rotZ = TryParseFloat(rotationZInput.text, parentSkyMap.rotation.eulerAngles.z);
        //parentSkyMap.rotation = Quaternion.Euler(rotX, rotY, rotZ);

        //float scaleX = TryParseFloat(scaleXInput.text, parentSkyMap.localScale.x);
        //float scaleY = TryParseFloat(scaleYInput.text, parentSkyMap.localScale.y);
        //float scaleZ = TryParseFloat(scaleZInput.text, parentSkyMap.localScale.z);
        //parentSkyMap.localScale = new Vector3(scaleX, scaleY, scaleZ);

        //PlayerPrefs.SetFloat("SkyMapPosX", posX);
        //PlayerPrefs.SetFloat("SkyMapPosY", posY);
        //PlayerPrefs.SetFloat("SkyMapPosZ", posZ);
        //PlayerPrefs.SetFloat("SkyMapRotX", rotX);
        //PlayerPrefs.SetFloat("SkyMapRotY", rotY);
        //PlayerPrefs.SetFloat("SkyMapRotZ", rotZ);
        //PlayerPrefs.SetFloat("SkyMapScaleX", scaleX);
        //PlayerPrefs.SetFloat("SkyMapScaleY", scaleY);
        //PlayerPrefs.SetFloat("SkyMapScaleZ", scaleZ);
        //PlayerPrefs.Save();

        Debug.Log("Settings Applied1!");

        Vector3 currentPosition = parentSkyMap.position;

        float posY = TryParseFloat(positionYInput.text, currentPosition.y); // Only change Y position

        // Update the position, keeping X and Z unchanged
        parentSkyMap.position = new Vector3(currentPosition.x, posY, currentPosition.z);
        PlayerPrefs.SetFloat("SkyMapPosY", posY);
        PlayerPrefs.Save();


        Debug.Log("Settings Applied2!");
    }

    private float TryParseFloat(string input, float fallback)
    {
        if (float.TryParse(input, out float result))
        {
            return result;
        }
        else
        {
            return fallback;
        }
    }

    public void SaveSettingsToCSV()
    {
        // Get current position, rotation, and scale
        Vector3 position = parentSkyMap.position;
        Vector3 rotation = parentSkyMap.rotation.eulerAngles;
        Vector3 scale = parentSkyMap.localScale;

        // Prepare the data for CSV
        string csvContent = "Position X, Position Y, Position Z, Rotation X, Rotation Y, Rotation Z, Scale X, Scale Y, Scale Z\n";
        csvContent += $"{position.x},{position.y},{position.z},{rotation.x},{rotation.y},{rotation.z},{scale.x},{scale.y},{scale.z}\n";

        string filePath = Path.Combine(Application.persistentDataPath, "player_settings.csv");
        File.WriteAllText(filePath, csvContent);

        Debug.Log($"Settings saved to {filePath}");
    }

    // Close the settings panel without saving
    private void CloseSettings()
    {
        //if (pauseScreen.activeSelf)
        //{
        //    pauseScreenBackround.SetActive(false);
        //    pauseScreen.SetActive(false);
        //}

        // activePlayerScreen.SetActive(true);
        settingsPanel.SetActive(!settingsPanel.activeSelf);

        SetActivePlayerScreen(true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameManager.ChangePauseGameState(false);
    }
}
