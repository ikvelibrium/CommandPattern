using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public interface ICommand
    {
        void Invoke(Vector2 position);
        void Undo();
    }

