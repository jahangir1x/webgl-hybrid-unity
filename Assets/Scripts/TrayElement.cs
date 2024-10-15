using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrayElement : MonoBehaviour
{
    public int zincScore;
    public int ironScore;
    public int vitaminAScore;
    public int iodineScore;
    private PlayerScoreManager _playerScoreManager;
    private AudioSource _audioSource;

    private Button _button;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);
        _playerScoreManager = PlayerScoreManager.Instance;
    }

    private void OnButtonClick()
    {
        PlayerMovement.Instance.anim.Play("pick item", -1, 0f);
        _playerScoreManager.Process(zincScore, ironScore, vitaminAScore, iodineScore);
        bool isGoodElement = zincScore > 0 && ironScore > 0 && vitaminAScore > 0 && iodineScore > 0;
        GameObject uiObject = null;
        if (isGoodElement)
        {
            uiObject = Instantiate(_playerScoreManager.plusUIElement, CanvasHandler.Instance.transform);
            CanvasHandler.Instance.scoreIconAnimator.Play("pick good item", -1, 0f);
        }
        else
        {
            uiObject = Instantiate(_playerScoreManager.minusUIElement, CanvasHandler.Instance.transform);
            CanvasHandler.Instance.scoreIconAnimator.Play("pick bad item", -1, 0f);
        }

        uiObject.transform.position = transform.position;

        AudioManager.Instance.PlayElementPick(_audioSource.clip);

        gameObject.SetActive(false);
    }
}