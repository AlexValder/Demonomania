﻿using System;
using System.Collections.Generic;
using Demonomania.Scripts.MazeGen.Algo;
using Godot;

namespace Demonomania.Scripts.MazeGen {
    public class AlgorithmManager {
        private readonly Dictionary<string, Type> _types = new Dictionary<string, Type> {
            ["Randomized"] = typeof(RandomMaze),
            ["Binary Tree"] = typeof(BinaryTree),
            ["Sidewinder"] = typeof(Sidewinder),
            ["Kruskal"] = typeof(Kruskal),
            ["Hunt&Kill"] = typeof(HuntAndKill),
            ["Prim"] = typeof(Prim),
        };

        public AlgorithmManager(OptionButton button) {
            button?.Clear();
            foreach (var name in _types.Keys) {
                button?.AddItem(name);
            }
        }

        public AbstractMazeGen GetAlgorithm(string name, params object[] @params) {
            if (!_types.ContainsKey(name)) {
                throw new ArgumentOutOfRangeException($"Unknown algo: {name}");
            }

            return Activator.CreateInstance(_types[name], @params) as AbstractMazeGen;
        }
    }
}
