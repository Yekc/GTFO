using Cosmos.System;
using System;

namespace GTFO
{
    public static class KeyboardEx
    {
        public static bool TryReadKey(out ConsoleKeyInfo Key)
        {
            if (KeyboardManager.TryReadKey(out var KeyX))
            {
                Key = new(KeyX.KeyChar, KeyX.Key.ToConsoleKey(), KeyX.Modifiers == ConsoleModifiers.Shift, KeyX.Modifiers == ConsoleModifiers.Alt, KeyX.Modifiers == ConsoleModifiers.Control);
                return true;
            }

            Key = default;
            return false;
        }

        public static ConsoleKeyInfo? ReadKey()
        {
            if (TryReadKey(out ConsoleKeyInfo Key))
            {
                return Key;
            }

            return null;
        }
    }
}
