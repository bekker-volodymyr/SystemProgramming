namespace MyLibrary
{
    public class Beeper
    {
        public int Frequency { get; set; }
        public int Duration { get; set; }

        public Beeper() { }

        public void DoBeep()
        {
            Console.Beep(Frequency, Duration);
        }
    }
}
