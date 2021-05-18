using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject TrainingPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void OpenTraining()
    {
        TrainingPanel.SetActive(true);
    }

    public void CloseTraining()
    {
        TrainingPanel.SetActive(false);
    }
}
