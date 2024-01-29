using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _planetHealthBarImage;

    [SerializeField]
    private GameObject _gameOverScreen;
    [SerializeField]
    private TextMeshProUGUI _gameOverText;

    void Start()
    {
        // Initial UI State
        UpdateScore(0);
        UpdateLives(3);
        UpdatePlanetHealth(100);
    }

    public void UpdateScore(float points)
    {
        _scoreText.text = points.ToString();
    }

    public void UpdatePlanetHealth(float planetHealth)
    {
        if(planetHealth > 66)
        {
            _planetHealthBarImage.color = new Color32(117, 229, 113, 255);
        }
        else if (planetHealth > 33)
        {
            _planetHealthBarImage.color = new Color32(243, 149, 73, 255);
        }
        else
        {
            _planetHealthBarImage.color = new Color32(255, 53, 53, 255);
        }

        _planetHealthBarImage.fillAmount = planetHealth / 100;
    }

    public void ShowGameOverUI(bool playerDestroyed)
    {
        if(playerDestroyed)
        {
            _gameOverText.text = "You have died, there is nobody left to defend earth, the voiders have defeated you";
        }
        else
        {
            _gameOverText.text = "You have failed to defend Earth and the planet has been destroyed";
        }

        _gameOverScreen.SetActive(true);
    }

    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _liveSprites[currentLives];
    }
}
