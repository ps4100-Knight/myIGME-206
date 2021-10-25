using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT2Q10
{

    public abstract class Reading
    {
        public string BookName;
        public string Author;
        public string type;

        public virtual void reading()
        {

        }
    }

    public interface IPaperBack
    {
        void Read();
    }

    public interface IEBook
    {
        void Purchase();
    }

    public class PaperBack : Reading, IPaperBack
    {
        public bool HardCover;

        public void Read()
        {
            Console.WriteLine("Read from PaperBack book");
        }

        public void Purchase()
        {

        }
    }

    public class Ebook : Reading, IEBook
    {
        public string Website;

        public void Purchase()
        {

        }

        public void Read()
        {
            Console.WriteLine("Read from Ebook");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PaperBack book1 = new PaperBack();
            Ebook book2 = new Ebook();
            MyMethod(book1);
            MyMethod(book2);
        }
        static void MyMethod(object obj)
        {
            try
            {
                ((PaperBack)obj).Read();
            }
            catch
            {
                ((Ebook)obj).Read();
            }
        }
    }
}
public class Zoo
{
    private string name;
    private string value;

    public string Name
    {
        get => this.name = value;

        set
        {
            value = name;
        }
    }
}

