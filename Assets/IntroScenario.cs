using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScenario : MonoBehaviour
{
    [SerializeField]
    private GameObject      textPressAnykey;
    // Start is called before the first frame update
    
    private void Awake()
    {
        StartCoroutine("Scenario");
    }
    
    private IEnumerator Scenario()
    {
        textPressAnykey.SetActive(true);

        while (true)
        {
            if(Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("Game");
            }
            yield return null;
        }
    }
}
