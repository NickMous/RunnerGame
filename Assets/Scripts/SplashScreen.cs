using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    private TextMeshProUGUI companyName;
    private TextMeshProUGUI slogan;
    private RawImage logo;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        companyName = GameObject.Find("Company Name").GetComponent<TextMeshProUGUI>();
        slogan = GameObject.Find("Slogan").GetComponent<TextMeshProUGUI>();
        logo = GameObject.Find("Logo").GetComponent<RawImage>();
        
        companyName.canvasRenderer.SetAlpha(0.0f);
        slogan.canvasRenderer.SetAlpha(0.0f);
        logo.canvasRenderer.SetAlpha(0.0f);
        
        companyName.CrossFadeAlpha(1.0f, 1.5f, false);
        logo.CrossFadeAlpha(1.0f, 1.5f, false);

        yield return new WaitForSeconds(1.5f);
        
        slogan.CrossFadeAlpha(1.0f, 1.5f, false);
        
        yield return new WaitForSeconds(3f);
        
        companyName.CrossFadeAlpha(0.0f, 1.5f, false);
        slogan.CrossFadeAlpha(0.0f, 1.5f, false);
        logo.CrossFadeAlpha(0.0f, 1.5f, false);

        yield return new WaitForSeconds(1.5f);
        
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
