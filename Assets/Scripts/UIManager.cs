using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text username;
    public void StartGame()
    {

        GameManager.Instance.currentUsername = username.text;
        GameManager.Instance.LoadRecords();
        SceneManager.LoadScene("main");
    }

}
