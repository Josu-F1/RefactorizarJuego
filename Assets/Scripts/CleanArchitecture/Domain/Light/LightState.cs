namespace CleanArchitecture.Domain.Light
{
    public readonly struct LightState
    {
        public readonly bool Enabled;

        public LightState(bool enabled)
        {
            Enabled = enabled;
        }
    }
}
