﻿using Maze.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.App
{
    internal delegate void LevelFinishedHandler(EndResult result);

    class LevelWorkflow
    {
        private GameEnvironment[] _levels;
        private int _currentLevelIndex = 0;
        private int _width, _height;
        public GameEnvironment CurrentLevel { get; private set; }
        public event LevelFinishedHandler OnLevelFinished, OnGameFinished;

        public LevelWorkflow(int width, int height)
        {
            _width = width;
            _height = height;

            _levels = new[]
                {
                    new GameEnvironment(width, height),
                    new GameEnvironment(width, height),
                    new GameEnvironment(width, height),
                    new GameEnvironment(width, height)
                };
            CurrentLevel = _levels[_currentLevelIndex];
            CurrentLevel.OnGameFinish += LevelFinished;
            OnLevelFinished = (r) => { };
            OnGameFinished = (r) => { };
        }

        private void NextLevel()
        {
            if (_currentLevelIndex == _levels.Length - 1)
            {
                OnGameFinished(EndResult.PlayerWon);
                return;
            }
            CurrentLevel = _levels[++_currentLevelIndex];
            CurrentLevel.OnGameFinish += LevelFinished;
        }

        private void RestartLeve()
        {
            CurrentLevel = new GameEnvironment(_width, _height);
            CurrentLevel.OnGameFinish += LevelFinished;
        }

        private void LevelFinished(EndResult result)
        {
            if (result == EndResult.CpuWon)
                RestartLeve();
            else
                NextLevel();
            OnLevelFinished(result);
        }

    }
}
