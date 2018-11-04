﻿using System;

namespace DEV_5
{
    class CountAllCommand : ICommand
    {
        private Collection Reciver { get; set; }

        public CountAllCommand(Collection reciver)
        {
            Reciver = reciver;
        }

        public void Execute()
        {
            Console.WriteLine(Reciver.CountAll()); 
        }
    }
}
