# DingoDanger

A multi-platform, curses based, C#, top-down shooter with wonky controls because C# has few multi-platform options for light-weight keyboard grabbing.

## How to play

* Windows
    1. Download the appropriate binary package from the [Releases](https://github.com/naelstrof/2420-DingoDanger/releases) page.
    2. Download and install [.NET 4.0](https://www.microsoft.com/en-us/download/details.aspx?id=17851) or equivalent.
    3. The game must be ran through a terminal emulator like cmd.exe. Double clicking on DingoDanger.exe will suffice, but using a better terminal emulator like cygwin or putty is recommended.

* Linux
    1. Download the appropriate binary package from the [Releases](https://github.com/naelstrof/2420-DingoDanger/releases) page.
    2. Compile/install mono from your local repository.
    2. Compile/install curses-sharp from your local repository.
    3. Run `mono DingoDanger.exe` in your favorite POSIX compliant terminal emulator (gnome-terminal, xterm, etc).
