public enum DialDirection
{
    Left = 0,
    Right = 1
}

public class Dial
{
    int _dialPosition;
    int _dialMaximimumPosition;

    public int DialPosition
    {
        get => _dialPosition;
    }

    public Dial(int startinPosition = 0, int dialMaximimumPosition = 99)
    {
        if (startinPosition < 0 || startinPosition >= dialMaximimumPosition)
        {
            throw new ArgumentException($"{nameof(startinPosition)} has to be >= 0 && < dialMaximumPosition");
        }

        _dialPosition = startinPosition;
        _dialMaximimumPosition = dialMaximimumPosition;
    }

    public void MoveDial(DialDirection direction)
    {
        int newDialPosition = _dialPosition;

        if (direction == DialDirection.Left) newDialPosition -= 1;
        else newDialPosition += 1;

        if (newDialPosition > _dialMaximimumPosition) newDialPosition = 0;
        else if (newDialPosition < 0) newDialPosition = _dialMaximimumPosition;

        _dialPosition = newDialPosition;
    }
}