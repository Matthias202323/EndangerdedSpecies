using ConsoleApp3.Models;
using System.Linq;

namespace ConsoleApp3
{
    internal class Program
    {
        public static void Main()
        {
            using (var context = new AnimalContext())
            {
                context.Database.EnsureDeleted();
                // Then I recreate it
                context.Database.EnsureCreated();

                var specie1 = new Species
                {
                    Name = "White cougar"
                };
                var specie2 = new Species
                {
                    Name = "White tiger"
                };
                var specie3 = new Species
                {
                    Name = "Albinos turtle"
                };

                
                context.Add(specie1);
                context.Add(specie2);
                context.Add(specie3);
                for (int i = 0; i < 3; i++)
                {

                    var animal = new Animals
                    {
                        Name = "White cougar",
                        DateOfBirth = DateTime.Now,
                        Species = specie1,
                    };
                    context.Add(animal);

                }
                for (int i = 0; i < 100; i++)
                {

                    var animal = new Animals
                    {
                        Name = "White tiger",
                        DateOfBirth = DateTime.Now,
                        Species = specie2,
                    };
                    context.Add(animal);

                }
                for (int i = 0; i < 15; i++)
                {

                    var animal = new Animals
                    {
                        Name = "Albinos turtle",
                        DateOfBirth = DateTime.Now,
                        Species = specie3,
                    };
                    context.Add(animal);
                }
                // After the shop is added, his relatonships will too
                // if they are defined          
                context.SaveChanges();
                
                // Once changes are added, they must be saved to the database
                // unless you will have an unexisting one 
                IQueryable<Species> inner = context.Species.Where((s) => s.Name == "White cougar");
                IQueryable<Animals> outer = context.Animals.Where((a) => a.Name == "White cougar");


                var categorySubcategories = outer

                                            .SelectMany(

                                            collectionSelector: category => inner

                                            .Where(subcategory => category.Name == subcategory.Name),



                                            resultSelector: (category, subcategory) =>

                                            new { Category = category.Name, Subcategory = subcategory.Name });

              Console.WriteLine("White cougar : " + " " + categorySubcategories.Count());

                IQueryable<Species> innertable = context.Species.Where((s) => s.Name == "White tiger");
                IQueryable<Animals> outertable = context.Animals.Where((a) => a.Name == "White tiger");


                var categorySubcategories2 = outertable

                                            .SelectMany(

                                            collectionSelector: category => innertable

                                            .Where(subcategory => category.Name == subcategory.Name),



                                            resultSelector: (category, subcategory) =>

                                            new { Category = category.Name, Subcategory = subcategory.Name });

                Console.WriteLine("White tiger : " + " " + categorySubcategories2.Count());


                IQueryable<Species> inner2 = context.Species.Where((s) => s.Name == "Albinos turtle");
                IQueryable<Animals> outer2 = context.Animals.Where((a) => a.Name == "Albinos turtle");


                var categorySubcategories3 = outer2

                                            .SelectMany(

                                            collectionSelector: category => inner2
                                            
                                            .Where(subcategory => category.Name == subcategory.Name),



                                            resultSelector: (category, subcategory) =>

                                            new { Category = category.Name, Subcategory = subcategory.Name });

                Console.WriteLine("Albinos turtle : " + " " + categorySubcategories3.Count());
                /* var whiteCougarSpecies = context.Species.Where((s) => s.Name == "White cougar");
                 IQueryable<Animals> whiteCougars = context.Animals.Where((a) => a.Species == whiteCougarSpecies);
                 whiteCougars.WriteLines();*/
            }
        }
    }

}
