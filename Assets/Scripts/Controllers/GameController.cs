using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController bgController;
    public ChooseController chooseController;
    

    private State state = State.IDLE;

    
    private enum State
    {
        IDLE, ANIMATE, CHOOSE 
    }
    void Start()
    {
         if(currentScene is StoryScene) 
        { 
            StoryScene storyScene = currentScene as StoryScene;
            bottomBar.PlayScene(storyScene);
            bgController.SetImage(storyScene.background);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (state == State.IDLE && bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence())
                {
                    
                    PlayScene((currentScene as StoryScene).nextScene);
                }
                else
                {
                    bottomBar.PlayNextSentence();
                }
                
            }
        }
    }

    public void PlayScene(GameScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }
    private IEnumerator SwitchScene(GameScene scene)
    {
        state = State.ANIMATE;
        currentScene = scene;
        bottomBar.BarOff();
        yield return new WaitForSeconds(1f);
        if(scene is StoryScene) 
        { 
            StoryScene storyScene = scene as StoryScene;
             bgController.SwitchImage(storyScene.background);
             yield return new WaitForSeconds(1f);
              bottomBar.ClearText();
             bottomBar.BarOn();
             yield return new WaitForSeconds(1f);
             bottomBar.PlayScene(storyScene);
             state = State.IDLE;

        }
        else if (scene is ChooseScene)
        {
            state = State.CHOOSE;
            chooseController.SetupChoose(scene as ChooseScene);

        }
        
        
       

    }
}
