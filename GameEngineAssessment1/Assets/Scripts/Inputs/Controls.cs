using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputNamespace
{
    class Controls
    {
        public Dictionary<KeyBind, string> keyBinds = new Dictionary<KeyBind, string>();
        public Dictionary<string, KeyBind> binds = new Dictionary<string, KeyBind>();
        public KeyBind moveFoward { get; private set; }
        public KeyBind moveBack { get; private set; }
        public KeyBind moveLeft { get; private set; }
        public KeyBind moveRight { get; private set; }
        public KeyBind turnLeft { get; private set; }
        public KeyBind turnRight { get; private set; }
        public KeyBind shoot { get; private set; }

        public Controls(KeyBind moveFoward, KeyBind moveBack, KeyBind moveLeft, KeyBind moveRight, KeyBind turnLeft, KeyBind turnRight, KeyBind shoot)
        { 
            this.moveFoward = moveFoward;
            this.moveBack = moveBack;
            this.moveLeft = moveLeft;
            this.moveRight = moveRight;
            this.turnLeft = turnLeft;
            this.turnRight = turnRight;
            this.shoot = shoot;

            AddToDictionaries(moveFoward, "Move Foward");
            AddToDictionaries(moveBack, "Move Back");
            AddToDictionaries(moveLeft, "Move Left");
            AddToDictionaries(moveRight, "Move Right");
            AddToDictionaries(turnLeft, "Turn Left");
            AddToDictionaries(turnRight, "Turn Right");
            AddToDictionaries(shoot, "Shoot");
        }

        void AddToDictionaries(KeyBind keyBind, string name)
        {
            keyBinds.Add(keyBind, name);
            binds.Add(name, keyBind);
        }
        /// <summary>
        /// The default right-handed controls
        /// </summary>
        /// <returns></returns>
        public static Controls DefaultKBM()
        {
            return new Controls(new KeyBind(KeyCode.W) + new KeyBind(KeyCode.UpArrow),
                new KeyBind(KeyCode.S) + new KeyBind(KeyCode.DownArrow),
                new KeyBind(KeyCode.A) + new KeyBind(KeyCode.LeftArrow),
                new KeyBind(KeyCode.D) + new KeyBind(KeyCode.RightArrow),
                new KeyBind(KeyCode.A) + new KeyBind(KeyCode.LeftArrow),
                new KeyBind(KeyCode.D) + new KeyBind(KeyCode.RightArrow),
                new KeyBind(KeyCode.Space)+ new KeyBind(KeyCode.Mouse0));
        }

        /// <summary>
        /// The default left-handed controls
        /// </summary>
        /// <returns></returns>
        //public static Controls LeftHandedKBM()
        //{
        //    return new Controls(new KeyBind(KeyCode.J) + new KeyBind(KeyCode.LeftArrow),
        //        new KeyBind(KeyCode.L) + new KeyBind(KeyCode.RightArrow));
        //}

        public static Controls DefaultController()
        {
            return new Controls(new KeyBind(KeyCode.W) + new KeyBind(KeyCode.UpArrow),
                new KeyBind(KeyCode.S) + new KeyBind(KeyCode.DownArrow),
                new KeyBind(KeyCode.A) + new KeyBind(KeyCode.LeftArrow),
                new KeyBind(KeyCode.D) + new KeyBind(KeyCode.RightArrow),
                new KeyBind(KeyCode.A) + new KeyBind(KeyCode.LeftArrow),
                new KeyBind(KeyCode.D) + new KeyBind(KeyCode.RightArrow),
                new KeyBind(KeyCode.Space) + new KeyBind(KeyCode.Mouse0));
        }

        public void Update()
        {
            KeyBind[] keys = new KeyBind[keyBinds.Count];
            keyBinds.Keys.CopyTo(keys, 0);
            for (int i = 0; i < keys.Length; i++)
            {
                keys[i].SetDown();
                keys[i].SetPressed();
                keys[i].SetUp();
            }
        }

        public void SaveKeys()
        {
            //TODO implement
        }
    }

    struct BindState
    {
        internal delegate bool Active();
        internal Active active;
        internal Active altActive;
        public bool IsActive;
    }

    class KeyBind
    {
        public bool mainIsBound = true;
        public bool altIsBound = false;
        KeyCode keyBind;
        KeyCode altKeyBind;
        public string keyBindName { get; private set; }
        public string altKeyBindName { get; private set; }
        BindState Pressed = new BindState();
        BindState Down = new BindState();
        BindState Up = new BindState();

        /// <summary>
        /// Allows two keybinds to be added together to add an alternitve input to the first one. Could check if alt is null first to determine if anything is overridden.
        /// </summary>
        public static KeyBind operator +(KeyBind a, KeyBind b)
        {
            a.altKeyBind = b.keyBind;
            a.altKeyBindName = b.keyBindName;
            a.Pressed.altActive = b.Pressed.active;
            a.Down.altActive = b.Down.active;
            a.Up.altActive = b.Up.active;
            a.altIsBound = true;
            return a;
        }

        public void UnBindMain()
        {
            mainIsBound = false;
        }

        public void UnBindAlt()
        {
            altIsBound = false;
        }

        public static void ChangeMainBind(ref KeyBind oldBind, KeyBind keyBind)
        {
            keyBind.Pressed.altActive = oldBind.Pressed.altActive;
            keyBind.Down.altActive = oldBind.Down.altActive;
            keyBind.Up.altActive = oldBind.Up.altActive;

            oldBind.keyBind = keyBind.keyBind;
            oldBind.keyBindName = keyBind.keyBindName;
            oldBind.Pressed = keyBind.Pressed;
            oldBind.Down = keyBind.Down;
            oldBind.Up = keyBind.Up;
            oldBind.mainIsBound = true;
        }
        /// <summary>
        /// For keys on the keyboard
        /// </summary>
        /// <param name="keyCode"></param>
        public KeyBind(KeyCode keyCode)
        {
            keyBind = keyCode;
            keyBindName = keyCode.ToString();
            if (keyBindName.Contains("Alpha"))
                keyBindName = keyBindName.Remove(0, 5);
            Pressed.active = KeyPressed;
            Down.active = KeyDown;
            Up.active = KeyUp;
            mainIsBound = true;
        }

        public KeyBind()
        {
            Input.GetAxis("Horizontal");
        }

        /// <summary>
        /// For mouse buttons
        /// </summary>
        /// <param name="mouseButton">0 is the left mouse button, 1 is the right mouse button and 2 is the middle mouse button</param>
        //public KeyBind(int mouseButton)
        //{
        //    keyBind = mouseButton;
        //    if (keyBind.ToString() == "0")
        //        keyBindName = "LMB";
        //    else if (keyBind.ToString() == "1")
        //        keyBindName = "RMB";
        //    if (keyBind.ToString() == "2")
        //        keyBindName = "MMB";

        //    Pressed.active = MouseButtonPressed;
        //    Down.active = MouseButtonDown;
        //    Up.active = MouseButtonUp;
        //}

        public bool IsPressed()
        {
            return Pressed.IsActive;
        }

        public bool IsDown()
        {
            return Down.IsActive;
        }

        public bool IsUp()
        {
            return Up.IsActive;
        }

        public void SetPressed()
        {
            if (altIsBound && mainIsBound)
                Pressed.IsActive = Pressed.altActive() || Pressed.active();
            else if (altIsBound)
                Pressed.IsActive = Pressed.altActive();
            else if (mainIsBound)
                Pressed.IsActive = Pressed.active();
        }

        public void SetDown()
        {
            if (altIsBound && mainIsBound)
                Down.IsActive = Down.altActive() || Down.active();
            else if (altIsBound)
                Down.IsActive = Down.altActive();
            else if (mainIsBound)
                Down.IsActive = Down.active();
        }

        public void SetUp()
        {
            if (altIsBound && mainIsBound)
                Up.IsActive = Up.altActive() || Up.active();
            else if (altIsBound)
                Up.IsActive = Up.altActive();
            else if (mainIsBound)
                Up.IsActive = Up.active();
        }

        bool KeyPressed()
        {
            return Input.GetKey((KeyCode)keyBind);
        }

        bool KeyDown()
        {
            return Input.GetKeyDown((KeyCode)keyBind);
        }

        bool KeyUp()
        {
            return Input.GetKeyUp((KeyCode)keyBind);
        }

        bool MouseButtonPressed()
        {
            return Input.GetMouseButton((int)keyBind);
        }

        bool MouseButtonDown()
        {
            return Input.GetMouseButtonDown((int)keyBind);
        }

        bool MouseButtonUp()
        {
            return Input.GetMouseButtonUp((int)keyBind);
        }

        public KeyCode GetBind()
        {
            return keyBind;
        }

        public KeyCode GetAltBind()
        {
            return altKeyBind;
        }
    }
}