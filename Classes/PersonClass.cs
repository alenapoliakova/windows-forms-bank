using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    public class Person : IPerson
    {
        public int CardNumber { get; }
        public string Name { get; }
        public DateTime Birthday { get; }
        public Person(int cardNumber, string name, DateTime birthday)
        {
            this.CardNumber = cardNumber;
            this.Name = name;
            this.Birthday = birthday;
        }
        public int calcAge(DateTime date)
        {
            var today = DateTime.Today;
            return ((today.Year * 100 + today.Month) * 100 + today.Day - (Birthday.Year * 100 + Birthday.Month) * 100 + Birthday.Day) / 10000;
        }
        public override string ToString()
        {
            DateTime Date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            return Name + " - " + calcAge(Date).ToString();
        }
    }
}
