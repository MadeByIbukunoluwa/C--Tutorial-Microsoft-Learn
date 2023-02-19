namespace TeleprompterConsole;
using static System.Math;


internal class TeleprompterConfig
{
    public int DelayInMilliSeconds { get; private set; }
    public void UpdateDelay(int increment)
    {
        
        var newDelay = Min(DelayInMilliSeconds + increment, 1000);
        newDelay = Max(newDelay, 20);
        DelayInMilliSeconds = newDelay;
    }
    public bool Done { get; private set; }
    public void SetDone()
    {
        Done = true;
    }
}