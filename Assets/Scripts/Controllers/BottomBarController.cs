using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;
    private int _sentenceIndex = -1;
    public StoryScene currentScene;
    private State state =State.COMPLETED;
    public Animator animator;
    private bool _isOff;

    private enum State 
    {
        PLAYING, COMPLETED
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    public void BarOff()
    {
        if (!_isOff)
        {
            animator.SetTrigger("BarOff");
            _isOff = true;
        }
        
    }
    public void BarOn()
    {
        animator.SetTrigger("BarOn");
        _isOff = false;
    }
    public void ClearText()
    {
        barText.text = "";
    }
    public void PlayScene (StoryScene scene)
    {
        currentScene = scene;
        _sentenceIndex = -1;
        PlayNextSentence();
    }
    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(currentScene.sentences[++_sentenceIndex].text));
        personNameText.text = currentScene.sentences[_sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[_sentenceIndex].speaker.textColor;
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return _sentenceIndex + 1 == currentScene.sentences.Count;
    }

    private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if(++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }

        }
    } 
}
