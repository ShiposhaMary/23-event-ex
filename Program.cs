using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_ex
{
    class Revision
    {
        public string Text { get; set; }
        public int CoursorPosition { get; set; }
    }

    class Program
    {
        static TextBox box;
        static List<Revision> revisions = new List<Revision>();

        static void MakeRevision(object sender, EventArgs args)//событие
        {
            revisions.Add(new Revision
            {
                Text = box.Text,
                CoursorPosition = box.SelectionStart
            });
        }

        public static void Main()
        {
            box = new TextBox { Multiline = true };
            box.Dock = DockStyle.Fill;

            box.TextChanged += MakeRevision;
            box.MouseDown += MakeRevision;
            //за счет того, что все классы аргументов событий выведены из EventArgs
            //мы можем подписывать универсальные методы на разные по типу события,
            //и при этом не использовать object

            var form = new Form();
            form.Controls.Add(box);
            Application.Run(form);
        }
    }
}
