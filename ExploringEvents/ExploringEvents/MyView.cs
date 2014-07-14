using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSC160_ConsoleMenu;


namespace ExploringEvents
{
    public delegate void MyClickDelegate(string s);

    /// <summary>
    /// This program lets us practice using delegates as event handlers.
    /// Prompts the user at the console to "click" a button
    /// 
    /// Blake Rollins
    /// 
    /// </summary>
    class MyView
    {


        /// <summary>
        /// Code to handle a button click
        /// </summary>
        /// <param name="s">The button name</param>
        public void ButtonClick_Handler(string s)
        {
            Console.WriteLine("{0} was clicked", s);
        }

        /// <summary>
        /// Go!
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MyView v1 = new MyView();
            MyButton b1 = new MyButton("OK");
            MyButton b2 = new MyButton("Cancel");
            MyButton b3 = new MyButton("Bob");
            b1.ClickEvent += v1.ButtonClick_Handler;
            b2.ClickEvent += v1.ButtonClick_Handler;
            b3.ClickEvent += v1.ButtonClick_Handler;

            List<string> options = new List<string>() {
                "Click OK",
                "Click Cancel",
                "Click Boc",
                "Click All"
            };

            bool running = true;
            while (running)
            {
                int selection = CSC160_ConsoleMenu.CIO.PromptForMenuSelection(options, true);

                switch (selection)
                {
                    case 0:
                        running = false;
                        break;
                    case 1:
                        b1.ClickButton();
                        break;
                    case 2:
                        b2.ClickButton();
                        break;
                    case 3:
                        b3.ClickButton();
                        break;
                    case 4:
                        b1.ClickButton();
                        b2.ClickButton();
                        b3.ClickButton();
                        break;
                }
            }
        }
    }
}
