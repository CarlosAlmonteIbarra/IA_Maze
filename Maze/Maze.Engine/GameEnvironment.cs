using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Engine.Objects;
using Maze.Engine.AI;

namespace Maze.Engine
{
    public class GameEnvironment
    {
        public event GameFinishHandler OnGameFinish;

        private Player _player;
        private CPU _cpu;
        private CollitionProcessor _collitionProcessor;
        private static float RIVAL_SPEED = 0.5f;


        public List<GameObject> Walls { get; private set; }
        public Character Player { get { return _player; } }
        public Character Enemy { get { return _cpu; } }
        public GameObject Goal { get; private set; }

        public GameEnvironment(int windowWidth, int windowHeight)
        {
            float wallThickness = 8f;
            int rows = 15;
            float size = (windowHeight - (wallThickness * (rows + 1))) / rows;
            int columns = (windowWidth - (int)wallThickness) / (int)(size+wallThickness);
            
            Builder builder = new Builder(rows, columns, size, wallThickness);
            Walls = builder.Walls;
            
            float pSize = size * 0.80f;
            float pPadding = (size - pSize) / 2;

            float y = Walls[1].Y + wallThickness + pPadding;
            float x = wallThickness + pPadding;

            _player = new Player(x, y, pSize, pSize, 2);

            Cell start = builder.Cells[0, columns - 1];
            Cell goal = builder.Cells[rows - 1, columns / 2];
            Goal = goal;
            ShortestPathStrategy cpuStrategy = new ShortestPathStrategy(builder.MazeGraph, builder.Cells, start, goal);
            x += (columns-1) * (pSize + wallThickness + (pPadding*2));
            _cpu = new CPU(x, y, pSize, pSize, RIVAL_SPEED, cpuStrategy);
            cpuStrategy.CPU = _cpu;

            List<GameObject> gameObjects = new List<GameObject>();
            //gameObjects.Add(_player);
            //gameObjects.Add(_cpu);
            foreach (GameObject w in Walls)
                gameObjects.Add(w);
            _collitionProcessor = new CollitionProcessor(windowWidth, windowHeight, gameObjects);
            cpuStrategy.CollitionProcessor = _collitionProcessor;

            OnGameFinish = new GameFinishHandler(CheckResult);
        }

        public void Tick()
        {
            _cpu.ApplyStrategy();
            ReachedGoal(_cpu);
        }

        public void MoveRight()
        {
            _player.Move(Direction.Right);
            _collitionProcessor.CheckForCollition(_player, Direction.Right);
            ReachedGoal(_player);
        }
        public void MoveLeft()
        {
            _player.Move(Direction.Left);
            _collitionProcessor.CheckForCollition(_player, Direction.Left);
            ReachedGoal(_player);
        }
        public void MoveUp()
        {
            _player.Move(Direction.Up);
            _collitionProcessor.CheckForCollition(_player, Direction.Up);
            ReachedGoal(_player);
        }
        public void MoveDown()
        {
            _player.Move(Direction.Down);
            _collitionProcessor.CheckForCollition(_player, Direction.Down);
            ReachedGoal(_player);
        }

        private bool ReachedGoal(Character c)
        {
            if (!_collitionProcessor.Intersection(c, Goal))
                return false;
            if (c is Player)
                OnGameFinish(EndResult.PlayerWon);
            else
                OnGameFinish(EndResult.CpuWon);
            return true;
        }

        private void CheckResult(EndResult result)
        {
            RIVAL_SPEED += 0.25f;
        }

    }
}
