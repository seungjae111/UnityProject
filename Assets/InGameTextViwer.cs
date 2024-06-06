using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameTextViwer : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private TextMeshProUGUI textScore;

    private void Update()
    {
        textScore.text = "Score"+ gameController.Score;
    }
}
