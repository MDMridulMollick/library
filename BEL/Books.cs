using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
   public class Books
    {

        //private int _id;
        private int _quantity;
        private string _name;
        private string _edition;
        private string _author;
        private string _title;
        private string _department;

        // public int Id { get => _id; set => _id = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public string Name { get => _name; set => _name = value; }
        public string Edition { get => _edition; set => _edition = value; }
        public string Author { get => _author; set => _author = value; }
        public string Title { get => _title; set => _title = value; }
        public string Department { get => _department; set => _department = value; }
    }
}
