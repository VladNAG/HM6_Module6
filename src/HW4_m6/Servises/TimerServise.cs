using HM4_M6.Interface;

namespace HM4_M6.Servises
{
    public class TimerServise : ITimer
    {
        public DateTime DatTime() => DateTime.Now;
    }
}
