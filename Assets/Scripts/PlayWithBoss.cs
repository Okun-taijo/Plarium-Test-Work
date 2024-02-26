using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayWithBoss : MonoBehaviour
{
    public void GoToMainBossScene()
    {
        SceneManager.LoadScene("BossScene");
    }

    public void GoToMainBossLessScene()
    {
        SceneManager.LoadScene("BosslessScene");
    }
}
