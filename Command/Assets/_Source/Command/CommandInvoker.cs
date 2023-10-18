using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker 
{
    private const int CAPACITY = 10;

    private List<ICommand> _commandQueue;

    private ICommand _rKM;
    private ICommand _lKM;

    public CommandInvoker( Transform player)
    {
        _rKM = new RKM(player);
        _lKM = new LKM(player);

        _commandQueue = new List<ICommand>();
    }
    public void Execute(ClickButton clickButton, Vector3 position)
    {
        if (clickButton == ClickButton.LKM)
        {
            _lKM.Invoke(position);
            _commandQueue.Add(_lKM);
        }
        else if (clickButton == ClickButton.RKM)
        {
            _rKM.Invoke(position);
            _commandQueue.Add(_rKM);
        }

        if (_commandQueue.Count > CAPACITY)
        {
            _commandQueue.RemoveAt(0);
        }
           
    }

    public void ExecuteRightClickCommands()
    {
        RKM rk = (RKM)_rKM;
        rk.Execute();
    }

    public void Undo()
    {
        if (_commandQueue.Count > 0)
        {
            Debug.Log("sdsd");
            _commandQueue[_commandQueue.Count - 1].Undo();
            _commandQueue.RemoveAt(_commandQueue.Count - 1);
        }
    }
}
