using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        { }
    }
}

/*
 * 1.- We have to have Single Responsability for Log Type of Messages and another class to implement the log in diferents repositories
 * 2.- Open for extension and Closed for modifications using diferents methods for each type of log
 * 3.- Liskov Subtitution and Interface Segregation using interfaces IJobLogger and ILogRepository also having an abstrac class to implement common functionaility
 * 4.- Dependency Inversion using the technique of Dependency injection and depending juts for abstractcion like the ILogRepository and injecting by construnctor on IJobLogger
 */
