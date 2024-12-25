using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] private Sprite[] instructionSprites;
    [SerializeField] private int currentInstructionIndex;
    [SerializeField] private Image instructionImage;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void disableInstructionPanel()
    {
        gameObject.SetActive(false);
        PlayerScoreManager.Instance.StartGame();
    }

    public void goToNextInstruction()
    {
        currentInstructionIndex++;
        if (currentInstructionIndex >= instructionSprites.Length)
        {
            currentInstructionIndex = instructionSprites.Length - 1;
            _animator.Play("instruction_hide");
            return;
        }

        instructionImage.sprite = instructionSprites[currentInstructionIndex];
    }
}
