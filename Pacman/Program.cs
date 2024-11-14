using System.IO;

int PacmanX = 1, PacmanY = 1;
int Score = 0;
char[,] map =
    {
        { '#', '#', '#', '#','#', '#','#', '#','#', '#','#', '#','#', '#',},
        { '#', ' ', '.', '.','#', ' ',' ', ' ',' ', ' ',' ', ' ',' ', '#',},
        { '#', '#', '#', '.','#', '#','#', '#',' ', ' ',' ', ' ',' ', '#',},
        { '#', ' ', '#', '.','.', '.','.', '#',' ', ' ','#', ' ',' ', '#',},
        { '#', ' ', '#', '.','.', '#','.', '#',' ', ' ','#', ' ',' ', '#',},
        { '#', ' ', '#', '.','.', '#','.', '#','#', '#','#', ' ','#', '#',},
        { '#', ' ', '#', '#','#', '#','.', ' ',' ', '#',' ', ' ',' ', '#',},
        { '#', ' ', '#', ' ',' ', '#','.', ' ',' ', '#',' ', ' ',' ', '#',},
        { '#', ' ', ' ', ' ',' ', ' ',' ', '#',' ', ' ',' ', ' ',' ', '#',},
        { '#', ' ', '#', ' ',' ', ' ',' ', '#',' ', ' ',' ', ' ',' ', '#',},
        { '#', '#', '#', '#','#', '#','#', '#','#', '#','#', '#','#', '#',},
    };
Console.CursorVisible = false;
ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);

while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Blue;
    DrawMap(map);

    Console.SetCursorPosition(PacmanX, PacmanY);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("@");

    Console.SetCursorPosition(15, 0);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Score: {Score}");

    pressedKey = Console.ReadKey();

    HandleInput(pressedKey, ref PacmanX, ref PacmanY, map);
}
/*char[,] ReadMap(string path)
{
    string[] file = File.ReadAllLines(path);

    char[,] map = new char[file[0].Length, file.Length];

    for (int x = 0; x < map.GetLength(0); x++)
    {
        for (int y = 0; y < map.GetLength(1); y++)
        {
            map[x, y] = file[y][x];
        }
    }
    return map;
}*/


void HandleInput(ConsoleKeyInfo pressedKey, ref int PacmanX, ref int PacmanY, char[,] map)
{
    int[] direction = GetDirection(pressedKey);
    
    int nextPositionX = PacmanX + direction[0];
    int nextPositionY = PacmanY + direction[1];
    if (map[nextPositionY, nextPositionX] != '#')
    {
        if (map[nextPositionY, nextPositionX] == '.')
        {
            Score++;
            map[nextPositionY, nextPositionX] = ' ';
        }
        PacmanX = nextPositionX;
        PacmanY = nextPositionY;
    }
}

int[] GetDirection(ConsoleKeyInfo pressedKey)
{
    int[] direction = { 0, 0 };
    if (pressedKey.Key == ConsoleKey.UpArrow)
        direction[1] = -1;
    else if (pressedKey.Key == ConsoleKey.DownArrow)
        direction[1] = 1;
    else if (pressedKey.Key == ConsoleKey.LeftArrow)
        direction[0] = -1;
    else if (pressedKey.Key == ConsoleKey.RightArrow)
        direction[0] = 1;

    return direction;
}

void DrawMap(char[,] map)
{
    for (int x = 0; x < map.GetLength(0); x++)
    {
        for (int y = 0; y < map.GetLength(1); y++)
        {
            Console.Write(map[x, y]);
        }
        Console.WriteLine();
    }
}
