using Pustok.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Pustok.ViewModels
{
    public class IndexPage
    {
       public  List<Sliders> Sliders { get; set; }
       public  List<Books> Books{ get; set; }
        public List<Features> Features { get; set; }
        public List<Books> FeaturedBooks { get; set; }
        public List<Books> NewBooks { get; set; }
        public List<Books> DiscountedBooks { get; set; }
    }
}
