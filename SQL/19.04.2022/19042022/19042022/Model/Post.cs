using System;
using System.Collections.Generic;
using System.Text;

namespace _19042022.Model
{
    internal class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public void ShowInfo()
        {
            Console.WriteLine($"Id : {Id},Title : {Title},Content : {Content}");
        }
    }
}
