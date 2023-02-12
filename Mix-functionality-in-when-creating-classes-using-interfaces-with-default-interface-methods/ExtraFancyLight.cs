namespace mixins_with_interfaces
{
    public class ExtraFancyLight : IBlinkingLight, ITimerLight, ILight
    {
        private bool isOn;
        public void SwitchOn() => isOn = true;
        public void SwitchOff() => isOn = false;
        public bool IsOn() => isOn;
        public async Task Blink(int duration, int repeatCount)
        {
            Console.WriteLine("Extra Fancy Light starting the Blink function");
            await Task.Delay(duration * repeatCount);
            Console.WriteLine("Extra fancy light has finished the blink function");
        }
        public async Task TurnOnFor(int duration)
        {
            Console.WriteLine("Extra Fancy light starting timer function");
            await Task.Delay(duration);
            Console.WriteLine("Extra fancy Light finished custom timer function");
        }

        public override string ToString() => $"The light is {isOn: \"on\", \"off\"}";
    }
}