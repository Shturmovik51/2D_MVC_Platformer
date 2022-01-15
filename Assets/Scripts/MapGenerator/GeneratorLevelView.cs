using UnityEngine.Tilemaps;
using UnityEngine;

namespace Platformer2D
{
    public class GeneratorLevelView
    {
        public Tilemap Tilemap { get; }
        public Tile GroundTile { get; }
        public Tile GrassTile { get; }
        public int MapHeight { get; }
        public int MapWidth { get; }
        public bool Borders { get; }
        public int FillPercent { get; }
        public int FactorSmooth { get; }

        public GeneratorLevelView(StarterGameData starterGameData)
        {
            Tilemap = starterGameData.Tilemap;
            GroundTile = starterGameData.GroundTile;
            GrassTile = starterGameData.GrassTile;
            MapHeight = starterGameData.MapHeight;
            MapWidth = starterGameData.MapWidth;
            Borders = starterGameData.Borders;
            FillPercent = starterGameData.FillPercent;
            FactorSmooth = starterGameData.FactorSmooth;
        }        
    }
}
