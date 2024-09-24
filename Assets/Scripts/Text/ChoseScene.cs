using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewChooseScene",  menuName = "Data/New Choose Scene")]
[System.Serializable]

public class ChoseScene : GameScene
{
    public List<ChoseScene> labels;
    [System.Serializable]

    public struct ChooseLable
    {
        public string text;
        public StoryScene nextScene;
    }
}
