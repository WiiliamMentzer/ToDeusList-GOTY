using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TItleScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Object;
    public void MoveToScene()
    {
        SceneManager.LoadScene(1); 
    }
    public void ExitScene()
    {
        m_Object.text = "You Cannot Leave.";
    }
}
