using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject panel;

    [SerializeField] private Text distanceText;
    private void Start()
    {
        Time.timeScale = 1;
        distanceText = FindObjectOfType<Text>();
        distanceText.text = TravelledRange() + " M";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        distanceText.text = (int) TravelledRange() + " M";
        if (!Rotate.isAngleClose)
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private float TravelledRange()
    {
        return  Vector3.Distance(player.transform.position,transform.position);
    }
}


