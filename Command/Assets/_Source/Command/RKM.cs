using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RKM : ICommand
{
    private List<Vector3> _positions = new List<Vector3>();
    private Transform _player;
    private int _counter = 0;
    public void Invoke(Vector2 position )
    {
        _positions.Add(position);
        _counter++;
    }
    public RKM(Transform player)
    {
        _player = player;
    }
    public void Execute()
    {
        for (int i = 0; i < _positions.Count; i++)
        {
            _player.transform.position = _positions[i];
        }
    }
    public void Undo()
    {
        if (_positions.Count > 0)
        {
             _player.transform.position = _positions[_counter - 1];
            _counter--;
            _positions.RemoveAt(_positions.Count - 1);
        }
    }
}
