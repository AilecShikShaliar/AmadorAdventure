using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController bgController;
    void Start()
    {
        bottomBar.PlayScene(currentScene);
        bgController.SetImage(currentScene.background);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence())
                {
                    currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
                    bgController.SwitchImage(currentScene.background);


                }
                else
                {
                    bottomBar.PlayNextSentence();
                }
                
            }
        }
    }
}
