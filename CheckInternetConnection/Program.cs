using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers; //Namespace ini digunakan untuk membuat timer yang running tiap 1 detik
namespace CheckInternetConnection
{
    public class InternetTimer
    {
        //Global timer
        private Timer _timer;
        //Boolean flag untuk deteksi timer sedang running atau tidak
        private bool _isTimerRunning;
        
        //Constructor
        public InternetTimer()
        {
            //Proses initialization variable _timer.
            //Disini  _timer akan running tiap 1 detik/ 1000 milliseconds
            _timer = new Timer()
            {
                Interval = 1000,
                Enabled = true
            };

            //Proses ini disebut subcribe/register event.
            //Karena timer running tiap 1 detik, timer akan memanggil event Elapsed.
            //Event ini akan memanggil fungsi TimerElapsed
            _timer.Elapsed += TimerElapsed;

        }
        
        //Method/fungsi ini digunakan untuk memulai timer
        public void StartTimer()
        {
            _isTimerRunning = true;
            _timer.Start();
        }

        //Method/fungsi ini digunakan untuk menghentikan timer
        public void StopTimer()
        {
            if(_isTimerRunning)
            {
                _timer.Stop();
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            //Check apakah ada koneksi internet
            if(InternetConnection.IsConnected())
            {
                Console.WriteLine("Internet status: Online");

            }
            else
            {
                Console.WriteLine("Internet status: Offline");
            }
        }
       
    }
    class Program
    {
        
        
        static void Main(string[] args)
        {
            InternetTimer internetTimer = new InternetTimer();
            internetTimer.StartTimer();
            Console.ReadLine();
            internetTimer.StopTimer();
            Environment.Exit(0);
        }
    }
}
