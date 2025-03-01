using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns
{
    namespace FacadePattern
    {
        public class Amplifier
        {
            public void On() => Console.WriteLine("Amplifier is on.");
            public void Off() => Console.WriteLine("Amplifier is off.");
            public void SetVolume(int level) => Console.WriteLine($"Setting volume to {level}");
        }
        public class Projector
        {
            public void On() => Console.WriteLine("Projector is on.");
            public void Off() => Console.WriteLine("Projector is off.");
            public void SetInput(string input) => Console.WriteLine($"Setting input to {input}");
        }
        public class Screen
        {
            public void Down() => Console.WriteLine("Screen is down.");
            public void Up() => Console.WriteLine("Screen is up.");
        }
        public class DVDPlayer
        {
            public void On() => Console.WriteLine("DVD player is on.");
            public void Off() => Console.WriteLine("DVD player is off.");
            public void Play(string movie) => Console.WriteLine($"Playing movie: {movie}");
        }
        public class HomeTheaterFacade
        {
            private Amplifier _amplifier;
            private Projector _projector;
            private Screen _screen;
            private DVDPlayer _dvdPlayer;

            public HomeTheaterFacade(Amplifier amplifier, Projector projector, Screen screen, DVDPlayer dvdPlayer)
            {
                _amplifier = amplifier;
                _projector = projector;
                _screen = screen;
                _dvdPlayer = dvdPlayer;
            }

            public void WatchMovie(string movie)
            {
                Console.WriteLine("\nGet ready to watch a movie...");
                _screen.Down();
                _projector.On();
                _projector.SetInput("DVD");
                _amplifier.On();
                _amplifier.SetVolume(5);
                _dvdPlayer.On();
                _dvdPlayer.Play(movie);
            }
            public void EndMovie()
            {
                Console.WriteLine("\nShutting movie theater down...");
                _dvdPlayer.Off();
                _amplifier.Off();
                _projector.Off();
                _screen.Up();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Amplifier amplifier = new Amplifier();
                Projector projector = new Projector();
                Screen screen = new Screen();
                DVDPlayer dvdPlayer = new DVDPlayer();
                HomeTheaterFacade homeTheater = new HomeTheaterFacade(amplifier, projector, screen, dvdPlayer);
                homeTheater.WatchMovie("The Matrix");
                homeTheater.EndMovie();
            }
        }
    }
}
