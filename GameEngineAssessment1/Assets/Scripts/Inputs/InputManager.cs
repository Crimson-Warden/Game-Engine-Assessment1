using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace InputNamespace
{
    class InputManager : MonoBehaviour
    {
        public static Controls currentControls
        {
            get
            {
                if (!controllerIsEnabled)
                    return KBMControls;
                else
                    return ControllerControls;
            }
        }

        static Controls KBMControls;
        static Controls ControllerControls;
        static bool leftHanded = false;
        static bool _ControllerIsEnabled = false;
        public static bool controllerIsEnabled
        {
            get { return _ControllerIsEnabled; }
            private set { _ControllerIsEnabled = value; }
        }

        private void Start()
        {
            KBMControls = Controls.DefaultKBM();
            ControllerControls = Controls.DefaultController();
        }

        private void Update()
        {
            currentControls.Update();
        }

        public static List<KeyBind> GetKeyBinds()
        {
            List<KeyBind> keyBinds = currentControls.keyBinds.Keys.ToList();
            return keyBinds;
        }

        public void ToggleUsingController()
        {
            controllerIsEnabled = !controllerIsEnabled;
        }
    }
}
