using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Dog _dog;
    [SerializeField] private int _pointsCount;
    [SerializeField] private float _roundTime;
    
    [Header("UI")]
    [SerializeField] private TMP_Text _playerPointText;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _playerResultText;
    [SerializeField] private GameObject _gameOverPanel;
    
    
    public void Update()
    {
        _roundTime -= Time.deltaTime;
        _timerText.SetText(_roundTime.ToString()); 
        
        _playerPointText.SetText(_dog.CollectedPoints.ToString());

        if (_roundTime <= 0.0f)
        {
            _playerResultText.SetText(_dog.CollectedPoints.ToString());
            _gameOverPanel.SetActive(true); 
        }

        if (_dog.CollectedPoints >= _pointsCount)
        {
            _playerResultText.SetText(_dog.CollectedPoints.ToString());
            _gameOverPanel.SetActive(true);
        }
    }

    public void OnStartNewGameClick()
    {
        SceneManager.LoadScene("SimpleNaturePack_Demo");
    }
    
}

