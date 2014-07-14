using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploringEvents
{
    /// <summary>
    /// Test button to practice delegates
    /// </summary>
    class MyButton
    {
        /// <summary>
        /// The Click event
        /// </summary>
        public MyClickDelegate ClickEvent;

        /// <summary>
        /// The Button name
        /// </summary>
        public string ButtonName { get; private set; }

        public MyButton(string buttonName)
        {
            ButtonName = buttonName;
        }

        /// <summary>
        /// Event that "clicks" the button
        /// </summary>
        public void ClickButton()
        {
            ClickEvent(ButtonName);
        }
    }
}
