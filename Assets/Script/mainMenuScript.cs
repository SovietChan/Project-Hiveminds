using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    public GameObject credit;
    public void clickPlay()
    {
        SceneManager.LoadScene(1);//buka scene pilih stage
    }
    public void showCredit()
    {
        credit.SetActive(true);
    }
    public void closeCredit()
    {
        credit.SetActive(false);
    }

}
