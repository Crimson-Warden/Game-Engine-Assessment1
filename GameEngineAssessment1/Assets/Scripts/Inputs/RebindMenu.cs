using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InputNamespace
{
    //TODO save binds to file
    //Have a apply conformation

    //THe class that handles the layout of the rebind menu
    class RebindMenu : MonoBehaviour
    {
        List<KeyBind> binds;
        [SerializeField]
        GameObject prefab;
        List<RebindButton> buttons = new List<RebindButton>();

        private void Start()
        {
            UpdateBinds();
        }

        public void UpdateBinds()
        {
            for(int i = 0; i < buttons.Count; i ++)
                Destroy(buttons[i].gameObject);
            buttons.Clear();
            binds = InputManager.GetKeyBinds();
            Dictionary<KeyBind, string> bindDict = InputManager.currentControls.keyBinds;

            binds.Reverse();
            for (int i = 0; i < binds.Count; i++)
            {
                RebindButton rebindButton = Instantiate(prefab, new Vector3(200, -160 + i * 50, 0), Quaternion.Euler(0, 0, 0), gameObject.transform).GetComponent<RebindButton>();
                rebindButton.NewRebindButton(binds[i], bindDict[binds[i]]);
                buttons.Add(rebindButton);
            }
        }
    }
}
