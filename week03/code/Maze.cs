
/// <summary>
/// Defines a maze using a dictionary.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left.
    /// </summary>
    public void MoveLeft()
    {
        if (!_mazeMap[(_currX, _currY)][0])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX--;
    }

    /// <summary>
    /// Check to see if you can move right.
    /// </summary>
    public void MoveRight()
    {
        if (!_mazeMap[(_currX, _currY)][1])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currX++;
    }

    /// <summary>
    /// Check to see if you can move up.
    /// </summary>
    public void MoveUp()
    {
        if (!_mazeMap[(_currX, _currY)][2])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY--;
    }

    /// <summary>
    /// Check to see if you can move down.
    /// </summary>
    public void MoveDown()
    {
        if (!_mazeMap[(_currX, _currY)][3])
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        _currY++;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
