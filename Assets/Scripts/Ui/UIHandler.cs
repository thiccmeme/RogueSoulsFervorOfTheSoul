using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    GameObject _pauseMenu;

    [SerializeField]
    GameObject _optionsMenu, _gameMenu;

    [SerializeField]
    GameObject _heartsDisplay;

    [SerializeField]
    Transform _heartDisplayHandlePosition;

    GameObject _currentMenu;

    [SerializeField]
    GameObject _ammoLayout;
    [SerializeField]
    TMP_Text _ammoCounter;
    [SerializeField]
    TMP_Text _maxAmmoNumber;
    PlayerWeapon _targetWeapon;

    [SerializeField]
    GameObject _reloadingText;

    PlayerStats _playerStats;

    public GameObject inventory;
    public GameObject innerInventory;
    private EventManager2 eventManager2;

    public bool IsPaused {  get; private set; }

    private void Awake()
    {
        _playerStats = GetComponentInParent<PlayerStats>();
    }

    private void Start()
    {
        CloseAllMenus();
        _reloadingText.SetActive(false);
        _pauseMenu.SetActive(false);
        inventory.transform.localScale = new Vector3(0, 0, 0);
        //inventory.GetComponentInChildren<Image>().enabled = false;
        //innerInventory.GetComponent<Image>().enabled = false;
        eventManager2 = FindFirstObjectByType<EventManager2>();
    }

    public void SetGun(PlayerWeapon gun)
    {
        _targetWeapon = gun;
    }

    private void FixedUpdate()
    {
        if (!_targetWeapon)
        {
            _ammoLayout.SetActive(false);
        }
        else
        {
            _ammoLayout.SetActive(true);
            _ammoCounter.text = _targetWeapon.CurrentAmmo.ToString();
            _maxAmmoNumber.text = "/ " + _targetWeapon.MaxAmmo.ToString();
        }
    }

    public void TogglePauseMenu()
    {
        if (!_pauseMenu) return;
        
        if (_pauseMenu.activeSelf)
        {
            IsPaused = false;
            _pauseMenu.SetActive(false);
            //ChangeHealthDisplayParent(transform.parent);
            Time.timeScale = 1.0f;
        }
        else
        {
            IsPaused = true;
            _pauseMenu.SetActive(true);
            _currentMenu = _pauseMenu;
            OpenSpecificMenu(_currentMenu);
            Time.timeScale = 0.0f;
        }

    }

    private void ChangeHealthDisplayParent(Transform desiredParent)
    {
        _heartsDisplay.transform.SetParent(desiredParent);
        var heartDisplayTransform = _heartsDisplay.GetComponent<RectTransform>();
        heartDisplayTransform.anchoredPosition = Vector3.zero;
        //heartDisplayTransform.anchorMin = new Vector2(0, -0);
    }

    private void UpdateItemsCollectedText(TMP_Text targetText, int soulAmount)
    {
        targetText.text = soulAmount.ToString();
    }

    public void OpenSpecificMenu(GameObject menuToOpen)
    {
        CloseAllMenus();
        _currentMenu = menuToOpen;
        _currentMenu.SetActive(true);

        if (_currentMenu == inventory)
        {
            _pauseMenu.SetActive(false);
            inventory.transform.localScale = new Vector3(1, 1, 1);
            //inventory.GetComponentInChildren<Image>().enabled = true;
            //innerInventory.GetComponent<Image>().enabled = true;
        }

        if (_currentMenu != inventory)
        {
            inventory.transform.localScale = new Vector3(0, 0, 0);
            //inventory.GetComponentInChildren<Image>().enabled = false;
            //innerInventory.GetComponent<Image>().enabled = false;
        }
    }

    public void EnableReloadingText(float reloadTime)
    {
        _reloadingText.SetActive(true);
        Invoke(nameof(DisableReloadingText), reloadTime);
    }

    private void DisableReloadingText()
    {
        _reloadingText.SetActive(false);
    }

    private void CloseAllMenus()
    {
        _optionsMenu.SetActive(false);
        _gameMenu.SetActive(false);
    }
    

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenuTest");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
