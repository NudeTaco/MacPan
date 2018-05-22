using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MacPan
{
    class MapParser
    {
        StreamReader reader;
        public MapParser(String mapName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = String.Format("MacPan.Maps.{0}.txt", mapName);
            reader = new StreamReader(assembly.GetManifestResourceStream(resourceName));
            
        }
        public Tile.tiles[,] readMap()
        {
            int mapSize = int.Parse(reader.ReadLine());
            Tile.tiles[,] board = new Tile.tiles[mapSize,mapSize];
            int lineCount = 0;
            while(!reader.EndOfStream)
            {
                char[] temp = reader.ReadLine().ToCharArray();
                for(int i = 0; i<temp.Length; i++)
                {
                    board[lineCount, i] = (Tile.tiles)int.Parse(temp[i].ToString());
                }
                lineCount++;
            }
            return board;
        }
    }
}
