using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFishing
{
    internal class Game
    {
        public Game(string text, List<string> list, TextBox textProgress)
        {
            Text = text;
            List = list;
            TextProgress = textProgress;
        }

        public string Text { get; }
        public List<string> List { get; }
        public TextBox TextProgress { get; }

        public IEnumerable<string> GetPlayerCardName()
        {
            throw new NotImplementedException();
        }

        public string DescribeBooks()
        {
            throw new NotImplementedException();
        }

        public string DescribePlayerHends()
        {
            throw new NotImplementedException();
        }

        public bool PlayOneRound(int selectedIndex)
        {
            throw new NotImplementedException();
        }

        public string GetWinnerName()
        {
            throw new NotImplementedException();
        }
    }
}
