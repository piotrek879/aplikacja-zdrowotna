using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dzien { get; set; }
    }
}
