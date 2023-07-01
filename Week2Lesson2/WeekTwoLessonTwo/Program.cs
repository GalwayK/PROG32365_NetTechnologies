namespace WeekTwoLessonTwo
{
    public class Program
    {
        static void Main(string[] args)
        {
            ExerciseCoinFlip();
        }

        public static void ExerciseCoinFlip()
        {
            CoinFlip.FlipCoin();
        }

        public static void ExerciseHeartRateMonitor()
        {
            Console.Write("Please enter your first name: ");
            string strFirstName = Console.ReadLine();

            Console.Write("Please enter your last name: ");
            string strLastName = Console.ReadLine();

            Console.Write("Please enter the year of your birth: ");
            int intBirthyear = Convert.ToInt16(Console.ReadLine());

            int intCurrentYear = System.DateTime.UtcNow.Year;

            HeartRateMonitor.HeartRateMonitor monitor = new HeartRateMonitor.HeartRateMonitor(strFirstName, strLastName, intBirthyear, intCurrentYear);
        }
    }
}