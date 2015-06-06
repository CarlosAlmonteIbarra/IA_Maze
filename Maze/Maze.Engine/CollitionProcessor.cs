using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Engine.Objects;

namespace Maze.Engine
{
    class CollitionProcessor
    {
        private List<GameObject> _gameObjects;
        private float _width, _height;

        public CollitionProcessor(float width, float height, List<GameObject> gameObjects)
        {
            _gameObjects = gameObjects;
            _width = width;
            _height = height;
        }

        public bool CheckForCollition(GameObject gameObject, Direction movedTo)
        {
            float xw, yh;
            
            switch (movedTo)
            {
                case Direction.Right:
                    xw = gameObject.X + gameObject.Width;
                    foreach (GameObject go in _gameObjects)
                    {
                        if (gameObject == go || go == null)
                            continue;
                        if (IntersectionInY(gameObject, go) && xw > go.X && xw < go.X + go.Width)
                        {
                            gameObject.X = go.X - (gameObject.Width + 1);
                            return true;
                        }
                    }
                    if (xw > _width)
                    {
                        gameObject.X = _width - gameObject.Width;
                        return true;
                    }
                    break;
                case Direction.Left:
                    foreach (GameObject go in _gameObjects)
                    {
                        if (gameObject == go || go == null)
                            continue;
                        xw = go.X + go.Width;
                        if (IntersectionInY(gameObject, go) && gameObject.X < xw && gameObject.X > go.X)
                        {
                            gameObject.X = xw + 1;
                            return true;
                        }
                    }
                    if (gameObject.X < 0)
                    {
                        gameObject.X = 0;
                        return true;
                    }
                    break;
                case Direction.Up:
                    foreach (GameObject go in _gameObjects)
                    {
                        if (gameObject == go || go == null)
                            continue;
                        yh = go.Y + go.Height;
                        if (IntersectionInX(gameObject, go) && gameObject.Y < yh && gameObject.Y > go.Y)
                        {
                            gameObject.Y = yh + 1;
                            return true;
                        }
                    }
                    if (gameObject.Y < 0)
                    {
                        gameObject.Y = 0;
                        return true;
                    }
                    break;
                case Direction.Down:
                    yh = gameObject.Y + gameObject.Height;
                    foreach (GameObject go in _gameObjects)
                    {
                        if (gameObject == go || go == null)
                            continue;
                        if (IntersectionInX(gameObject, go) && yh > go.Y && yh < go.Y + go.Height)
                        {
                            gameObject.Y = go.Y - (gameObject.Height + 1);
                            return true;
                        }
                    }
                    if (yh > _height)
                    {
                        gameObject.Y = _height - gameObject.Height;
                        return true;
                    }
                    break;
            }

            return false;
        }

        private bool IntersectionInX(GameObject a, GameObject b)
        {
            float axw = a.X + a.Width;
            float bxw = b.X + b.Width;
            if (axw > b.X && a.X < bxw || a.X < b.X && axw > bxw)
                return true;
            return false;
        }

        private bool IntersectionInY(GameObject a, GameObject b)
        {
            float ayh = a.Y + a.Height;
            float byh = b.Y + b.Height;
            if (ayh > b.Y && a.Y < byh || a.Y < b.Y && ayh > byh)
                return true;
            return false;
        }

        public bool Intersection(GameObject a, GameObject b)
        {
            if (IntersectionInX(a, b) && IntersectionInY(a, b))
                return true;
            return false;
        }

    }
}
