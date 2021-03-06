using UnityEngine;
using UnityEngine.Tilemaps;

namespace Platformer2D
{
    public class GeneratorController : IInitializable, IController
    {
        private Tilemap _tilemap;
        private Tile _groundTile;
        private Tile _grassTile;
        private int _mapHeight;
        private int _mapWidth;
        private bool _borders;
        private int _fillPercent;
        private int _factorSmooth;

        private int[,] _map;

        private const int CountWall = 4;

        private MarshingSquaresController SquareGen;

        public GeneratorController(GeneratorLevelView levelView)
        {
            _tilemap = levelView.Tilemap;
            _groundTile = levelView.GroundTile;
            _grassTile = levelView.GrassTile;
            _mapHeight = levelView.MapHeight;
            _mapWidth = levelView.MapWidth;
            _factorSmooth = levelView.FactorSmooth;
            _fillPercent = levelView.FillPercent;
            _borders = levelView.Borders;

            _map = new int[_mapWidth, _mapHeight];
        }

        public void Initialization()
        {

            FillMap();

            for (int i = 0; i < _factorSmooth; i++)
            {
                SmoothMap();
            }

            DrawTiles();
            //DrawTilesWithMarshingSquares();     // ???????? Marching Squares (?????????? ????????)

        }


        private void FillMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    if (x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeight - 1)
                    {
                        if (_borders)
                        {
                            _map[x, y] = 1;
                        }
                    }
                    else
                    {
                        _map[x, y] = Random.Range(0, 100) < _fillPercent ? 1 : 0;
                    }
                }
            }
        }


        private void SmoothMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {
                    int neighbour = GetNeighbour(x, y);

                    if (neighbour > CountWall)
                    {
                        _map[x, y] = 1;
                    }
                    else if (neighbour < CountWall)
                    {
                        _map[x, y] = 0;
                    }

                }
            }
        }


        private int GetNeighbour(int x, int y)
        {
            int neighbourCounter = 0;

            for (int gridX = x - 1; gridX <= x + 1; gridX++)
            {
                for (int gridY = y - 1; gridY <= y + 1; gridY++)
                {
                    if (gridX >= 0 && gridX < _mapWidth && gridY >= 0 && gridY < _mapHeight)
                    {
                        if (gridX != x || gridY != y)
                        {
                            neighbourCounter += _map[gridX, gridY];
                        }
                    }
                    else
                    {
                        neighbourCounter++;
                    }
                }
            }

            return neighbourCounter;
        }


        private void DrawTiles()
        {

            if (_map == null)
            {
                return;
            }

            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeight; y++)
                {

                    Vector3Int tilePosition = new Vector3Int(-_mapWidth / 2 + x, -_mapHeight / 2 + y, 0);

                    if (_map[x, y] == 1)
                    {
                        if(y > 0 && y + 1 < _mapHeight)
                        {
                            if(_map[x, y + 1] == 0)
                                _tilemap.SetTile(tilePosition, _grassTile);
                            else
                                _tilemap.SetTile(tilePosition, _groundTile);
                        }
                        else
                        {
                            _tilemap.SetTile(tilePosition, _groundTile);
                        }
                    }
                }
            }
        }

        private void DrawTilesWithMarshingSquares()
        {
            SquareGen = new MarshingSquaresController();
            SquareGen.GenerateGrid(_map, 1);
            SquareGen.DrawTilesOnMap(_tilemap, _groundTile, _grassTile);
        }
    }
}
