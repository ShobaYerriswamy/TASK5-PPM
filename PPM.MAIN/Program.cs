using System;
using System.Xml.Serialization;  
using System.IO;  
using MODEL;
using UserInterface;

namespace Final
{
    static class Program
    {
        static void Main(string[] args)
        {
            Viewing view = new Viewing();
            view.View(); 
        }   
    }
}

