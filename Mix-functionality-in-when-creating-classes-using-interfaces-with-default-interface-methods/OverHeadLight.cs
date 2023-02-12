
namespace mixins_with_interfaces
{

    public class Overheadlight : ILight, ITimerLight, IBlinkingLight
    {
        private bool isOn;
        public bool IsOn() => isOn;
        public void SwitchOff() => isOn = false;
        public void SwitchOn() => isOn = true;

        public override string ToString() => $"The light is {(isOn ? "on" : "off")}";
    }
}