# DuckySharp

DuckySharp is a basic library interfacing Ducky keyboards' RGB features over USB HID.

**The methods used by this library were found through reverse engineering, and as such are not official. Use at your own risk.**

Tested with a One 2 RGB.

## Example

The following example will set all LEDs to white, then turn off after two seconds.

```cs

using DuckySharp;

// ...

Keyboard keyboard = new Keyboard();
keyboard.Initialize();

foreach (Key key in Keys.All)
	keyboard.SetKeyColor(key, new Color(255, 255, 255));

keyboard.Update()

Thread.Sleep(2000);
keyboard.Close();

```

## Credits

- [voximity](https://github.com/voximity) - Creator and maintainer
- [Project Aurora](https://github.com/antonpup/Aurora) - HID protocol reference
