using System;
using System.Collections.Generic;

namespace AnimalFarmDatabase
{
    public class Animal
    {
        public int Id { get; set; }
        
        public List<TextAttribute> TextAttributes { get; set;  }= new List<TextAttribute>();
        public List<IntAttribute> IntAttributes { get; set; }= new List<IntAttribute>();
        public List<DateTimeAttribute> DateTimeAttributes { get; set; }= new List<DateTimeAttribute>();
        
    }

    public abstract class Attribute<T>
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public T Value { get; set; }
    }

    public class TextAttribute : Attribute<String>
    {
    }
    public class IntAttribute : Attribute<int>
    {
    }
    public class DateTimeAttribute : Attribute<DateTime>
    {
    }
}
