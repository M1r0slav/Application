using System;


namespace Infrastructure.Models
{
  public class ConcertDate:BaseEntity<int> //Проявление на 1 концерт
    {
        public int ConcertId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public string Town { get; set; }
        public string Place { get; set; }
                
        public virtual Concert Concert { get; set; }
    }
}
