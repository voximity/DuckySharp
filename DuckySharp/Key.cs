using System;
using System.Collections.Generic;
using System.Text;

namespace DuckySharp {
    public static class Keys {
        // Y offsets for rows
        public static double FRow = 0.5;
        public static double Row1 = 2;
        public static double Row2 = 3;
        public static double Row3 = 4;
        public static double Row4 = 5;
        public static double Row5 = 6;

        // Special key widths
        public static double TabWidth = 1.5;
        public static double CapsWidth = 1.75;
        public static double LeftShiftWidth = 2.25;
        public static double SpecialWidth = 1.25;
        public static double SpaceWidth = 6.25;
        public static double RightShiftWidth = 2.75;
        public static double BackspaceWidth = 2;
        public static double BackslashWidth = 1.5;
        public static double EnterWidth = 2.25;

        public static Key Escape             = new Key(1, 24, 0.5, FRow);
        public static Key Tilde              = new Key(1, 27, 0.5, Row1);
        public static Key Tab                = new Key(1, 30, TabWidth / 2, Row2);
        public static Key CapsLock           = new Key(1, 33, CapsWidth / 2, Row3);
        public static Key LeftShift          = new Key(1, 36, LeftShiftWidth / 2, Row4);
        public static Key LeftControl        = new Key(1, 39, SpecialWidth / 2, Row5);

        public static Key One                = new Key(1, 45, 0.5 + 1, Row1);
        public static Key Q                  = new Key(1, 48, TabWidth / 2 + 1, Row2);
        public static Key A                  = new Key(1, 51, CapsWidth / 2 + 1, Row3);
        // some weird "uk backslash" thing here... i dont know where that is so im not adding it
        public static Key LeftWindows        = new Key(1, 57, SpecialWidth / 2 + SpecialWidth, Row5);

        public static Key F1                 = new Key(1, 60, 0.5 + 2, FRow);
        public static Key Two                = new Key(1, 63, 0.5 + 2, Row1);
        public static Key W                  = new Key(2, 6, TabWidth / 2 + 2, Row2);
        public static Key S                  = new Key(2, 9, CapsWidth / 2 + 2, Row3);
        public static Key Z                  = new Key(2, 12, LeftShiftWidth / 2 + 1, Row4);
        public static Key LeftAlt            = new Key(2, 15, SpecialWidth / 2 + SpecialWidth * 2, Row5);

        public static Key F2 = new Key(2, 18, F1.X + 1, FRow);
        public static Key Three = new Key(2, 21, Two.X + 1, Row1);
        public static Key E = new Key(2, 24, W.X + 1, Row2);
        public static Key D = new Key(2, 27, S.X + 1, Row3);
        public static Key X = new Key(2, 30, Z.X + 1, Row4);
        // something about JPN_MUHENKAN for JIS

        public static Key F3 = new Key(2, 36, F2.X + 1, FRow);
        public static Key Four = new Key(2, 39, Three.X + 1, Row1);
        public static Key R = new Key(2, 42, E.X + 1, Row2);
        public static Key F = new Key(2, 45, D.X + 1, Row3);
        public static Key C = new Key(2, 48, X.X + 1, Row4);
        // project aurora says "don't have a clue"

        public static Key F4 = new Key(2, 54, F3.X + 1, FRow);
        public static Key Five = new Key(2, 57, Four.X + 1, Row1);
        public static Key T = new Key(2, 60, R.X + 1, Row2);
        public static Key G = new Key(2, 63, F.X + 1, Row3);
        public static Key V = new Key(3, 6, C.X + 1, Row4);
        // ...
        // "These two are probably nothing."

        public static Key Six = new Key(3, 15, Five.X + 1, Row1);
        public static Key Y = new Key(3, 18, T.X + 1, Row2);
        public static Key H = new Key(3, 21, G.X + 1, Row3);
        public static Key B = new Key(3, 24, V.X + 1, Row4);
        public static Key Space = new Key(3, 27, LeftAlt.X + SpecialWidth / 2 + SpaceWidth / 2, Row5);

        public static Key F5 = new Key(3, 30, F4.X + 1.5, FRow);
        public static Key Seven = new Key(3, 33, Six.X + 1, Row1);
        public static Key U = new Key(3, 36, Y.X + 1, Row2);
        public static Key J = new Key(3, 39, H.X + 1, Row3);
        public static Key N = new Key(3, 42, B.X + 1, Row4);
        // very unlikely be JPN_HENKAN

        public static Key F6 = new Key(3, 48, F5.X + 1, FRow);
        public static Key Eight = new Key(3, 51, Seven.X + 1, Row1);
        public static Key I = new Key(3, 54, U.X + 1, Row2);
        public static Key K = new Key(3, 57, J.X + 1, Row3);
        public static Key M = new Key(3, 60, N.X + 1, Row4);
        // could be JPN_HENKAN

        public static Key F7 = new Key(4, 6, F6.X + 1, FRow);
        public static Key Nine = new Key(4, 9, Eight.X + 1, Row1);
        public static Key O = new Key(4, 12, I.X + 1, Row2);
        public static Key L = new Key(4, 15, K.X + 1, Row3);
        public static Key Comma = new Key(4, 18, M.X + 1, Row4);
        // could be JPN_HIRAGAN_KATAKANA key

        public static Key F8 = new Key(4, 24, F7.X + 1, FRow);
        public static Key Zero = new Key(4, 27, Nine.X + 1, Row1);
        public static Key P = new Key(4, 30, O.X + 1, Row2);
        public static Key Semicolon = new Key(4, 33, L.X + 1, Row3);
        public static Key Period = new Key(4, 36, Comma.X + 1, Row4);
        public static Key RightAlt = new Key(4, 39, Space.X + SpaceWidth / 2 + SpecialWidth / 2, Row5);

        public static Key F9 = new Key(4, 42, F8.X + 1.5, FRow);
        public static Key Minus = new Key(4, 45, Zero.X + 1, Row1);
        public static Key OpenBracket = new Key(4, 48, P.X + 1, Row2);
        public static Key Apostrophe = new Key(4, 51, Semicolon.X + 1, Row3);
        public static Key ForwardSlash = new Key(4, 54, Period.X + 1, Row4);
        // "Don't know."

        public static Key F10 = new Key(4, 60, F9.X + 1, FRow);
        public static new Key Equals = new Key(4, 63, Minus.X + 1, Row1);
        public static Key CloseBracket = new Key(5, 6, OpenBracket.X + 1, Row2);
        // public static Key Hashtag = new Key(5, 9, ) // I don't have this key, so I don't know where it's placed
        public static Key RightWindows = new Key(5, 15, RightAlt.X + SpecialWidth, Row5);

        public static Key F11 = new Key(5, 18, F10.X + 1, FRow);
        //
        //
        // "probably nothing"
        public static Key RightShift = new Key(5, 30, ForwardSlash.X + 0.5 + RightShiftWidth / 2, Row4);
        public static Key FunctionKey = new Key(5, 33, RightWindows.X + SpecialWidth, Row5);

        public static Key F12 = new Key(5, 36, F11.X + 1, FRow);
        public static Key Backspace = new Key(5, 39, Equals.X + 0.5 + BackspaceWidth / 2, Row1);
        public static Key Backslash = new Key(5, 42, CloseBracket.X + 0.5 + BackslashWidth / 2, Row2);
        public static Key Enter = new Key(5, 45, Apostrophe.X + 0.5 + EnterWidth / 2, Row3);
        public static Key RightControl = new Key(5, 51, FunctionKey.X + SpecialWidth, Row5);

        public static Key PrintScreen = new Key(5, 54, F12.X + 1.5, FRow);
        public static Key Insert = new Key(5, 57, PrintScreen.X, Row1);
        public static Key Delete = new Key(5, 60, PrintScreen.X, Row2);
        //
        //
        public static Key LeftArrow = new Key(6, 9, PrintScreen.X, Row5);

        public static Key ScrollLock = new Key(6, 12, PrintScreen.X + 1, FRow);
        public static Key Home = new Key(6, 15, ScrollLock.X, Row1);
        public static Key End = new Key(6, 18, ScrollLock.X, Row2);
        public static Key UpArrow = new Key(6, 24, ScrollLock.X, Row4);
        public static Key DownArrow = new Key(6, 27, ScrollLock.X, Row5);

        public static Key PauseBreak = new Key(6, 30, ScrollLock.X + 1, FRow);
        public static Key PageUp = new Key(6, 33, PauseBreak.X, Row1);
        public static Key PageDown = new Key(6, 36, PauseBreak.X, Row2);
        //
        //
        public static Key RightArrow = new Key(6, 45, PauseBreak.X, Row5);

        public static Key Calc = new Key(6, 48, PauseBreak.X + 1.5, FRow);
        public static Key NumLock = new Key(6, 51, Calc.X, Row1);
        public static Key NumSeven = new Key(6, 54, Calc.X, Row2);
        public static Key NumFour = new Key(6, 57, Calc.X, Row3);
        public static Key NumOne = new Key(6, 60, Calc.X, Row4);
        public static Key NumZero = new Key(6, 63, Calc.X + 0.5, Row5);

        public static Key VolumeMute = new Key(7, 6, Calc.X + 1, FRow);
        public static Key NumSlash = new Key(7, 9, VolumeMute.X, Row1);
        public static Key NumEight = new Key(7, 12, VolumeMute.X, Row2);
        public static Key NumFive = new Key(7, 15, VolumeMute.X, Row3);
        public static Key NumTwo = new Key(7, 18, VolumeMute.X, Row4);
        //

        public static Key VolumeDown = new Key(7, 24, VolumeMute.X + 1, FRow);
        public static Key NumAsterisk = new Key(7, 27, VolumeDown.X, Row1);
        public static Key NumNine = new Key(7, 30, VolumeDown.X, Row2);
        public static Key NumSix = new Key(7, 33, VolumeDown.X, Row3);
        public static Key NumThree = new Key(7, 36, VolumeDown.X, Row4);
        public static Key NumPeriod = new Key(7, 39, VolumeDown.X, Row5);

        public static Key VolumeUp = new Key(7, 42, VolumeDown.X + 1, FRow);
        public static Key NumMinus = new Key(7, 45, VolumeUp.X, Row1);
        public static Key NumPlus = new Key(7, 48, VolumeUp.X, Row2 + 0.5);
        //
        //
        public static Key NumEnter = new Key(7, 57, VolumeUp.X, Row4 + 0.5);

        /// <summary>
        /// A list of all registered keys.
        /// </summary>
        public static Key[] All = {
            Escape, Tilde, Tab, CapsLock, LeftShift, LeftControl,
            One, Q, A, LeftWindows,
            F1, Two, W, S, Z, LeftAlt,
            F2, Three, E, D, X,
            F3, Four, R, F, C,
            F4, Five, T, G, V,
            Six, Y, H, B, Space,
            F5, Seven, U, J, N,
            F6, Eight, I, K, M,
            F7, Nine, O, L, Comma,
            F8, Zero, P, Semicolon, Period, RightAlt,
            F9, Minus, OpenBracket, Apostrophe, ForwardSlash,
            F10, Equals, CloseBracket, RightWindows,
            F11, RightShift, FunctionKey,
            F12, Backspace, Backslash, Enter, RightControl,
            PrintScreen, Insert, Delete, LeftArrow,
            ScrollLock, Home, End, UpArrow, DownArrow,
            PauseBreak, PageUp, PageDown, RightArrow,
            Calc, NumLock, NumSeven, NumFour, NumOne, NumZero,
            VolumeMute, NumSlash, NumEight, NumFive, NumTwo,
            VolumeDown, NumAsterisk, NumNine, NumSix, NumThree, NumPeriod,
            VolumeUp, NumMinus, NumPlus, NumEnter
        };

        /// <summary>
        /// The width of the keyboard.
        /// </summary>
        public static double KeyboardWidth    = VolumeUp.X + 0.5;

        /// <summary>
        /// The width of the keyboard if it is TKL.
        /// </summary>
        public static double KeyboardWidthTKL = PauseBreak.X + 0.5;

        /// <summary>
        /// The height of the keyboard.
        /// </summary>
        public static double KeyboardHeight   = Row5 + 0.5;

    }

    public class Key {
        /// <summary>
        /// The X coordinate of the key on the keyboard. Coordinate (0, 0) is the top left of the escape key.
        /// </summary>
        public double X;

        /// <summary>
        /// The Y coordinate of the key on the keyboard. Coordinate (0, 0) is the top left of the escape key.
        /// </summary>
        public double Y;

        /// <summary>
        /// Which packet this key will be sent in in HID updates.
        /// </summary>
        public int PacketNum;

        /// <summary>
        /// The offset in this key's packet that its color information will be encoded.
        /// </summary>
        public int OffsetNum;
        
        /// <summary>
        /// Instantiate a key from the packet it corresponds to and its offset in the packet.
        /// </summary>
        /// <param name="packet">The packet number.</param>
        /// <param name="offset">The offset in the packet.</param>
        /// <param name="x">X position on the keyboard.</param>
        /// <param name="y">Y position on the keyboard.</param>
        public Key(int packet, int offset, double x, double y) {
            PacketNum = packet;
            OffsetNum = offset;
            X = x;
            Y = y;
        }
    }
}
