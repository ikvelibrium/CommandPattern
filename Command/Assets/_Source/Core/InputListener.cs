using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    private CommandInvoker _commandInvoker;
    private Camera _mainCamera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _commandInvoker.Execute(ClickButton.LKM, _mainCamera.ScreenToWorldPoint(Input.mousePosition));
        }   
        else if (Input.GetMouseButtonDown(1))
        {
            _commandInvoker.Execute(ClickButton.RKM, _mainCamera.ScreenToWorldPoint(Input.mousePosition));
        }    
        else if (Input.GetMouseButtonDown(2))
        {
            _commandInvoker.Undo();
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            _commandInvoker.ExecuteRightClickCommands();
        }
            
    }

    public void Construct(Camera mainCamera, CommandInvoker commandInvoker)
    {
        _mainCamera = mainCamera;
        _commandInvoker = commandInvoker;
    }
}
