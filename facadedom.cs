using System;
public class TV
{
    public void TurnOn()
    {
        Console.WriteLine("TV is turned on.");
    }

    public void SelectChannel(int level)
    {
        Console.WriteLine($"TV channel is select to {level}.");
    }

    public void TurnOff()
    {
        Console.WriteLine("TV is turned off.");
    }
}
public class AudioSystem
{
    public void TurnOn()
    {
        Console.WriteLine("Audio system is turned on.");
    }

    public void SetVolume(int level)
    {
        Console.WriteLine($"Audio volume is set to {level}.");
    }

    public void TurnOff()
    {
        Console.WriteLine("Audio system is turned off.");
    }
}

public class DVDPlayer
{
    public void Play()
    {
        Console.WriteLine("DVDPlayer is played.");
    }

    public void Pause()
    {
        Console.WriteLine($"DVDPlayer is paused.");
    }

    public void Stop()
    {
        Console.WriteLine("DVDPlayer is stopped.");
    }
}

public class GameConsole
{
    public void TurnOn()
    {
        Console.WriteLine("GameConsole is turned on.");
    }

    public void Play()
    {
        Console.WriteLine($"GameConsole is played.");
    }

}

public class HomeTheaterFacade
{
    private TV _tv;
    private AudioSystem _audioSystem;
    private DVDPlayer _dvdplayer;
    private GameConsole _gameconsole;

    public HomeTheaterFacade(TV tv, AudioSystem audioSystem, DVDPlayer dvdplayer, GameConsole gameconsole)
    {
        _tv = tv;
        _audioSystem = audioSystem;
        _dvdplayer = dvdplayer;
        _gameconsole = gameconsole;
    }

    public void StartMovie()
    {
        Console.WriteLine("Preparing to start the movie...");
        _tv.TurnOn();
        _tv.SelectChannel(5);
        _audioSystem.TurnOn();
        _audioSystem.SetVolume(8);
        _dvdplayer.Play();
        _gameconsole.TurnOn();
        _gameconsole.Play();
        Console.WriteLine("Movie started.");
    }

    public void EndMovie()
    {
        Console.WriteLine("Shutting down movie...");
        _dvdplayer.Stop();
        _audioSystem.TurnOff();
        _tv.TurnOff();
        Console.WriteLine("Movie ended.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        AudioSystem audio = new AudioSystem();
        DVDPlayer dvdplayer = new DVDPlayer();
        TV tv = new TV();
        GameConsole gameconsole = new GameConsole();

        HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, audio, dvdplayer, gameconsole);

        homeTheater.StartMovie();

        Console.WriteLine();

        homeTheater.EndMovie();
    }
}
