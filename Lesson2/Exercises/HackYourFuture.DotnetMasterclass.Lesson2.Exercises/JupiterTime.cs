using HackYourFuture.DotnetMasterclass.Lesson2.Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackYourFuture.DotnetMasterclass.Lesson2.Exercises
{

    internal class JupiterTime
    {
        private int hours; 
        private int minutes;

        public JupiterTime(int hours, int minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
        }
        public int Hours { get 
            {
                return hours;
            } set
            {
                if (hours == 0) hours = value;
                if (value < 0)
                {
                    hours -= value;
                }
                if (value > 0 && value <= 10)
                {
                    hours += value;
                }
            }
        }

        public int Minutes { get; set; }
        public void PrintTime() 
        {
            if (minutes < 10)
            {
                Console.WriteLine($"{hours}:0{minutes}");
                return;
            }
            Console.WriteLine($"{hours}:{minutes}");         
        }
        public void AddHour(int hour) 
        {
            this.hours += hour;
        }

        public void AddMinute(int minute)
        {
            this.hours += minute;
        }
    }

}
