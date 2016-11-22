﻿using System;

namespace LogsDB.Data.Models
{
    public class Log
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}