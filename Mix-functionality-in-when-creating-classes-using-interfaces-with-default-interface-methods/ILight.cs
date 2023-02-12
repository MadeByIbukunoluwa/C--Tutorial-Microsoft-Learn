namespace mixins_with_interfaces
{
    public enum PowerStatus
    {
        NoPower,
        ACPower,
        FullBattery,
        MidBattery,
        LowBattery
    }
    public interface ILight
    {
        void SwitchOn();
        void SwitchOff();
        bool IsOn();
        public PowerStatus Power() => PowerStatus.NoPower;
    }


}