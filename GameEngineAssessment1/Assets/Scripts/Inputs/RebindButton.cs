using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace InputNamespace
{
    //Class that allows rebinding for individual inputs
    class RebindButton : MonoBehaviour
    {
        KeyBind bind;
        bool isReadingKeyForMain = false;
        bool isReadingKeyForAlt = false;
        [SerializeField]
        Text mainText;
        [SerializeField]
        Text altText;
        [SerializeField]
        Text inputName;
        [SerializeField]
        GameObject promptPanel;
        [SerializeField]
        Button promptYes;
        [SerializeField]
        Button promptNo;
        [SerializeField]
        Text promptText;

        KeyBind toReplace;
        bool isReplacingMain = true;
        KeyBind newBind;
        KeyCode keyCode;
        bool newBindforMain = true;
        bool isPromptedToUnbind = false;
        string toReplaceName = "";

        private void Start()
        {
            promptYes.onClick.AddListener(UnBindAndApply);
            promptNo.onClick.AddListener(SetPromptingToFalse);
        }

        private void Update()
        {
            if (isReadingKeyForMain && !isPromptedToUnbind)
            {
                if (!InputManager.controllerIsEnabled)
                {
                    KeyBind newBind = ReadKey();
                    if (newBind != null)
                    {
                        ChangeMainInput(newBind);
                        mainText.text = newBind.keyBindName;
                        isReadingKeyForMain = false;
                    }
                }
                else
                {
                    //TODO Find New Controller Input
                }
            }
            if (isReadingKeyForAlt && !isPromptedToUnbind)
            {
                if (!InputManager.controllerIsEnabled)
                {
                    KeyBind newBind = ReadKey();
                    if (newBind != null)
                    {
                        ChangeAltInput(newBind);
                        altText.text = newBind.keyBindName;
                        isReadingKeyForAlt = false;
                    }
                }
                else
                {
                    //TODO Find New Controller Input
                }
            }

            if(!bind.mainIsBound)
            {
                mainText.text = "";
            }
            if(!bind.altIsBound)
            {
                altText.text = "";
            }
        }

        public void NewRebindButton(KeyBind bind, string name)
        {
            this.bind = bind;
            mainText.text = bind.keyBindName;
            altText.text = bind.altKeyBindName;
            inputName.text = name;
            gameObject.SetActive(true);
        }

        KeyBind ReadKey()
        {
            KeyBind bind = null;
            #region Letters
            CheckInput(KeyCode.A, ref bind);
            CheckInput(KeyCode.B, ref bind);
            CheckInput(KeyCode.C, ref bind);
            CheckInput(KeyCode.D, ref bind);
            CheckInput(KeyCode.E, ref bind);
            CheckInput(KeyCode.F, ref bind);
            CheckInput(KeyCode.G, ref bind);
            CheckInput(KeyCode.H, ref bind);
            CheckInput(KeyCode.I, ref bind);
            CheckInput(KeyCode.J, ref bind);
            CheckInput(KeyCode.K, ref bind);
            CheckInput(KeyCode.L, ref bind);
            CheckInput(KeyCode.M, ref bind);
            CheckInput(KeyCode.N, ref bind);
            CheckInput(KeyCode.O, ref bind);
            CheckInput(KeyCode.P, ref bind);
            CheckInput(KeyCode.Q, ref bind);
            CheckInput(KeyCode.R, ref bind);
            CheckInput(KeyCode.S, ref bind);
            CheckInput(KeyCode.T, ref bind);
            CheckInput(KeyCode.U, ref bind);
            CheckInput(KeyCode.V, ref bind);
            CheckInput(KeyCode.W, ref bind);
            CheckInput(KeyCode.X, ref bind);
            CheckInput(KeyCode.Y, ref bind);
            CheckInput(KeyCode.Z, ref bind);
            #endregion

            #region Numbers
            CheckInput(KeyCode.Alpha0, ref bind);
            CheckInput(KeyCode.Alpha1, ref bind);
            CheckInput(KeyCode.Alpha2, ref bind);
            CheckInput(KeyCode.Alpha3, ref bind);
            CheckInput(KeyCode.Alpha4, ref bind);
            CheckInput(KeyCode.Alpha5, ref bind);
            CheckInput(KeyCode.Alpha6, ref bind);
            CheckInput(KeyCode.Alpha7, ref bind);
            CheckInput(KeyCode.Alpha8, ref bind);
            CheckInput(KeyCode.Alpha9, ref bind);

            CheckInput(KeyCode.Keypad0, ref bind);
            CheckInput(KeyCode.Keypad1, ref bind);
            CheckInput(KeyCode.Keypad2, ref bind);
            CheckInput(KeyCode.Keypad3, ref bind);
            CheckInput(KeyCode.Keypad4, ref bind);
            CheckInput(KeyCode.Keypad5, ref bind);
            CheckInput(KeyCode.Keypad6, ref bind);
            CheckInput(KeyCode.Keypad7, ref bind);
            CheckInput(KeyCode.Keypad8, ref bind);
            CheckInput(KeyCode.Keypad9, ref bind);
            #endregion

            #region MouseButtons
            CheckInput(KeyCode.Mouse0, ref bind);
            CheckInput(KeyCode.Mouse1, ref bind);
            CheckInput(KeyCode.Mouse2, ref bind);
            CheckInput(KeyCode.Mouse3, ref bind);
            CheckInput(KeyCode.Mouse4, ref bind);
            CheckInput(KeyCode.Mouse5, ref bind);
            CheckInput(KeyCode.Mouse6, ref bind);
            #endregion

            #region FKeys
            CheckInput(KeyCode.F1, ref bind);
            CheckInput(KeyCode.F2, ref bind);
            CheckInput(KeyCode.F3, ref bind);
            CheckInput(KeyCode.F4, ref bind);
            CheckInput(KeyCode.F5, ref bind);
            CheckInput(KeyCode.F6, ref bind);
            CheckInput(KeyCode.F7, ref bind);
            CheckInput(KeyCode.F8, ref bind);
            CheckInput(KeyCode.F9, ref bind);
            CheckInput(KeyCode.F10, ref bind);
            CheckInput(KeyCode.F11, ref bind);
            CheckInput(KeyCode.F12, ref bind);
            CheckInput(KeyCode.F13, ref bind);
            CheckInput(KeyCode.F14, ref bind);
            CheckInput(KeyCode.F15, ref bind);
            #endregion

            #region Altkeys
            CheckInput(KeyCode.Ampersand, ref bind);
            CheckInput(KeyCode.Asterisk, ref bind);
            CheckInput(KeyCode.At, ref bind);
            CheckInput(KeyCode.Colon, ref bind);
            CheckInput(KeyCode.Dollar, ref bind);
            CheckInput(KeyCode.DoubleQuote, ref bind);
            CheckInput(KeyCode.Equals, ref bind);
            CheckInput(KeyCode.Exclaim, ref bind);
            CheckInput(KeyCode.Greater, ref bind);
            CheckInput(KeyCode.LeftParen, ref bind);
            CheckInput(KeyCode.Less, ref bind);
            CheckInput(KeyCode.Minus, ref bind);
            CheckInput(KeyCode.Plus, ref bind);
            CheckInput(KeyCode.Question, ref bind);
            CheckInput(KeyCode.RightBracket, ref bind);
            CheckInput(KeyCode.RightParen, ref bind);
            CheckInput(KeyCode.Underscore, ref bind);
            #endregion

            #region other
            CheckInput(KeyCode.AltGr, ref bind);
            CheckInput(KeyCode.BackQuote, ref bind);
            CheckInput(KeyCode.Backslash, ref bind);
            CheckInput(KeyCode.Caret, ref bind);
            CheckInput(KeyCode.Backspace, ref bind);
            CheckInput(KeyCode.Break, ref bind);
            CheckInput(KeyCode.CapsLock, ref bind);
            CheckInput(KeyCode.Clear, ref bind);
            CheckInput(KeyCode.Comma, ref bind);
            CheckInput(KeyCode.Delete, ref bind);
            CheckInput(KeyCode.DownArrow, ref bind);
            CheckInput(KeyCode.End, ref bind);
            CheckInput(KeyCode.Escape, ref bind);
            CheckInput(KeyCode.Hash, ref bind);
            CheckInput(KeyCode.Help, ref bind);
            CheckInput(KeyCode.Home, ref bind);
            CheckInput(KeyCode.Insert, ref bind);
            CheckInput(KeyCode.KeypadDivide, ref bind);
            CheckInput(KeyCode.KeypadEnter, ref bind);
            CheckInput(KeyCode.KeypadEquals, ref bind);
            CheckInput(KeyCode.KeypadMinus, ref bind);
            CheckInput(KeyCode.KeypadMultiply, ref bind);
            CheckInput(KeyCode.KeypadPeriod, ref bind);
            CheckInput(KeyCode.KeypadPlus, ref bind);
            CheckInput(KeyCode.LeftAlt, ref bind);
            CheckInput(KeyCode.LeftApple, ref bind);
            CheckInput(KeyCode.LeftArrow, ref bind);
            CheckInput(KeyCode.LeftBracket, ref bind);
            CheckInput(KeyCode.LeftCommand, ref bind);
            CheckInput(KeyCode.LeftControl, ref bind);
            CheckInput(KeyCode.LeftShift, ref bind);
            CheckInput(KeyCode.LeftWindows, ref bind);
            CheckInput(KeyCode.Menu, ref bind);
            CheckInput(KeyCode.Numlock, ref bind);
            CheckInput(KeyCode.PageDown, ref bind);
            CheckInput(KeyCode.PageUp, ref bind);
            CheckInput(KeyCode.Pause, ref bind);
            CheckInput(KeyCode.Period, ref bind);
            CheckInput(KeyCode.Print, ref bind);
            CheckInput(KeyCode.Quote, ref bind);
            CheckInput(KeyCode.Return, ref bind);
            CheckInput(KeyCode.RightAlt, ref bind);
            CheckInput(KeyCode.RightApple, ref bind);
            CheckInput(KeyCode.RightArrow, ref bind);
            CheckInput(KeyCode.RightCommand, ref bind);
            CheckInput(KeyCode.RightShift, ref bind);
            CheckInput(KeyCode.RightWindows, ref bind);
            CheckInput(KeyCode.ScrollLock, ref bind);
            CheckInput(KeyCode.Semicolon, ref bind);
            CheckInput(KeyCode.Slash, ref bind);
            CheckInput(KeyCode.Space, ref bind);
            CheckInput(KeyCode.SysReq, ref bind);
            CheckInput(KeyCode.Tab, ref bind);
            CheckInput(KeyCode.UpArrow, ref bind);
            #endregion
            return bind;
        }

        void CheckInput(KeyCode keyCode, ref KeyBind keyBind)
        {
            if (Input.GetKeyDown(keyCode))
            {
                if ((bind.GetBind() == keyCode && bind.mainIsBound) || bind.GetAltBind() == keyCode && bind.altIsBound)
                {
                    Debug.Log("Tried to change the bind to the same value");
                    isReadingKeyForMain = false;
                    isReadingKeyForAlt = false;
                    return;
                }
                if(bind.altIsBound && bind.GetAltBind() == keyCode && bind.altIsBound)
                {
                    Debug.Log("Tried to Make the Main and Alt bind the same.");
                    return;
                }
                List<KeyBind> list = InputManager.currentControls.keyBinds.Keys.ToList();
                list.Reverse();
                KeyCode[] altKeyCodes = new KeyCode[list.Count];
                KeyCode[] keyCodes = new KeyCode[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].mainIsBound)
                        keyCodes[i] = list[i].GetBind();
                    if (list[i].altIsBound)
                        altKeyCodes[i] = list[i].GetAltBind();
                }
                Debug.Log(keyCodes.Length);
                Debug.Log(altKeyCodes.Length);
                for (int i = 0; i < keyCodes.Length; i ++)
                {
                    if(keyCode == keyCodes[i])
                    {
                        Debug.Log("Duplicate Input");
                        //TODO Prompt the player to override if they want to
                        newBind = new KeyBind(keyCode);
                        this.keyCode = keyCode;
                        if (list[i] == null)
                            Debug.Log("its null??");
                        else
                        {
                            toReplace = list[i];
                            toReplaceName = InputManager.currentControls.keyBinds[list[i]];
                            Debug.Log(toReplaceName);
                        }
                        isReplacingMain = true;
                        if (isReadingKeyForMain)
                        {
                            newBindforMain = true;
                        }
                        else if (isReadingKeyForAlt)
                        {
                            newBindforMain = false;
                        }
                        Prompt();
                        return;
                    }
                }
                for (int i = 0; i < altKeyCodes.Length; i++)
                {
                    if (keyCode == altKeyCodes[i])
                    {
                        Debug.Log("Duplicate Input");
                        Prompt();
                        newBind = new KeyBind(keyCode);
                        if (list[i] == null)
                            Debug.Log("alts null??");
                        else
                        {
                            Debug.Log(toReplaceName);
                            toReplace = list[i];
                            toReplaceName = InputManager.currentControls.keyBinds[list[i]];
                        }
                        isReplacingMain = false;
                        if (isReadingKeyForMain)
                        {
                            newBindforMain = true;
                        }
                        else if (isReadingKeyForAlt)
                        {
                            newBindforMain = false;
                        }
                        Prompt();
                        return;
                    }
                }
                keyBind = new KeyBind(keyCode);
            }
        }

        private void Prompt()
        {
            isPromptedToUnbind = true;
            promptPanel.SetActive(true);
            string[] text = promptText.text.Split('_');
            promptText.text = text[0] + toReplaceName + text[1];
        }

        void ChangeMainInput(KeyBind bind)
        {
            KeyBind.ChangeMainBind(ref this.bind, bind);
            mainText.text = bind.keyBindName;
        }

        void ChangeAltInput(KeyBind bind)
        {
            this.bind += bind;
            altText.text = bind.keyBindName;
        }

        public void SetReadingKeyForMain(bool readingKey)
        {
            isReadingKeyForMain = readingKey;
        }

        public void SetReadingKeyForAlt(bool readingKey)
        {
            isReadingKeyForAlt = readingKey;
        }

        public void SetPromptingToFalse()
        {
            promptPanel.SetActive(false);
            isPromptedToUnbind = false;
        }

        public void UnBindAndApply()
        {
            if (isPromptedToUnbind)
            {
                if (newBindforMain)
                {
                    if (isReplacingMain)
                    {
                        InputManager.currentControls.binds[toReplaceName].UnBindMain();
                    }
                    else
                    {
                        InputManager.currentControls.binds[toReplaceName].UnBindAlt();
                    }
                    if (bind == null)
                        Debug.Log("bind is null");
                    if (newBind == null)
                        Debug.Log("newBind is null");
                    ChangeMainInput(new KeyBind(keyCode));
                    promptPanel.SetActive(false);
                    isReadingKeyForMain = false;
                    promptText.text = "This input is already used by _. Unbind it?";
                }
                else
                {
                    if (isReplacingMain)
                    {
                        InputManager.currentControls.binds[toReplaceName].UnBindMain();
                    }
                    else
                    {
                        InputManager.currentControls.binds[toReplaceName].UnBindAlt();
                    }
                    if (bind == null)
                        Debug.Log("bind is null");
                    if (newBind == null)
                        Debug.Log("newBind is null");

                    ChangeAltInput(new KeyBind(keyCode));
                    promptPanel.SetActive(false);
                    isReadingKeyForAlt = false;
                    promptText.text = "This input is already used by _. Unbind it?";
                }
                isPromptedToUnbind = false;
            }
        }
    }
}
