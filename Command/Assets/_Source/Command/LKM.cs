using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LKM : ICommand
{
    private List<Vector2> _positions = new List<Vector2>();
    private Transform _player;
    public void Invoke(Vector2 position)
    {
        _positions.Add(_player.position);
        _player.position = position;
    }

    public LKM(Transform player)
    {
        _player = player;
    }
    public void Undo()
    {
        if (_positions.Count > 0)
        {
            _player.position = _positions[_positions.Count - 1];
            _positions.RemoveAt(_positions.Count - 1);
        }
    }
}
