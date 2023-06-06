namespace HeartRateMonitor
{
    public class HeartRateMonitor
    {
        private string _firstName; 
        private string _lastName;
        private int _birthyear;
        private int _currentyear;

        public HeartRateMonitor(string firstname, string lastname, int birthyear, int currentyear)
        {
            int[] arrSets = new int[5];
            FirstName = firstname;
            LastName = lastname;
            Birthyear = birthyear;
            
        }

        public string FirstName
        {
            get { return _firstName; }  
            set { _firstName = value; }
        }

        public string LastName
        {
            get;
            set;
        }

        public int Age
        {
            get { return Currentyear - Birthyear; }
        }

        public int Birthyear
        {
            get => _birthyear;
            set => _birthyear = value;
        }

        public int Currentyear
        {
            get;
            set;
        }

        public int MaxHeartHeart
        {
            get => 220 - Age;
        }

        public double MaxTargetHeartRate
        {
            get => MaxHeartHeart * .85;
        }

        public int MinTargetHeartRate
        {
            get { return (MaxHeartHeart / 2) * ((int).5 * 2);  }
        }
    }
}
